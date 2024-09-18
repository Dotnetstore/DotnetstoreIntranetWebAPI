using Ardalis.Result;
using Dotnetstore.Intranet.Organization.UserInUserRoles;
using Dotnetstore.Intranet.Organization.UserRoles;
using Dotnetstore.Intranet.Organization.Users.Create;
using SDK.Dto.Organization.Users.Requests;
using SDK.Dto.Organization.Users.Responses;

namespace Dotnetstore.Intranet.Organization.Users;

internal sealed class UserService(IOrganizationUnitOfWork unitOfWork, IUserRepository repository) : IUserService
{
    async ValueTask<IEnumerable<UserResponse>> IUserService.GetAllAsync(CancellationToken cancellationToken)
    {
        var users = await repository.GetAllAsync(cancellationToken);
        return users.Select(user => user.ToUserResponse());
    }

    async ValueTask<IEnumerable<UserResponse>> IUserService.GetAllNotDeletedAsync(CancellationToken cancellationToken)
    {
        var users = await repository.GetAllNotDeletedAsync(cancellationToken);
        return users.Select(user => user.ToUserResponse());
    }

    async ValueTask<Result<UserResponse>> IUserService.CreateAsync(
        UserCreateRequest request, CancellationToken cancellationToken)
    {
        if (await UserExistsAsync(request.Username, cancellationToken))
            return Result.Conflict("User already exists");
        
        var user = CreateUser(request);
        
        await AddUserRolesAsync(user, cancellationToken);
        await SaveObjects(user, cancellationToken);

        return await GetCreatedUserAndReturnResponseAsync(user, cancellationToken);
    }
    
    private async ValueTask SaveObjects(User user, CancellationToken cancellationToken)
    {
        repository.Create(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
    
    private async ValueTask<Result<UserResponse>> GetCreatedUserAndReturnResponseAsync(
        User user, CancellationToken cancellationToken)
    {
        var createdUser = await repository.GetByIdAsync(user.UserId, cancellationToken);
        
        if (createdUser is null)
            return Result.NotFound("Something went wrong. User was not created.");
        
        return createdUser.ToUserResponse();
    }
    
    private async ValueTask AddUserRolesAsync(User user, CancellationToken cancellationToken)
    {
        var allUsers = await repository.GetAllNonSystemAsync(cancellationToken);

        if (allUsers.Count == 0)
            AddUserRole(user, Constants.UserRoleAdministratorId);
        
        AddUserRole(user, Constants.UserRoleUserId);
    }
    
    private async ValueTask<bool> UserExistsAsync(string username, CancellationToken cancellationToken)
    {
        var user = await repository.GetByUsernameAsync(username, cancellationToken);
        return user is not null;
    }

    private static User CreateUser(UserCreateRequest request)
    {
        return CreateUserBuilder.CreateNewUser()
            .CreateUserId()
            .SetPersonalData(request)
            .SetCredentials(request)
            .SetMetaData()
            .Build();
    }
    
    private void AddUserRole(User user, Guid userRoleId)
    {
        var userRole = new UserInUserRole
        {
            Id = new UserInUserRoleId(Guid.NewGuid()),
            UserId = user.UserId,
            UserRoleId = new UserRoleId(userRoleId), 
            CreatedDate = DateTimeOffset.Now
        };
        
        unitOfWork.Repository<UserInUserRole>().Create(userRole);
    }

    async ValueTask<Result<UserResponse>> IUserService.LoginAsync(UserLoginRequest request, CancellationToken cancellationToken)
    {
        var allNotDeletedUsers = await repository.GetAllNotDeletedAsync(cancellationToken);

        foreach (var user in allNotDeletedUsers)
        {
            if (user.Username != request.Username) continue;
            
            var verified = request.Password.Verify(
                user.Salt1, 
                user.Salt2, 
                user.Salt3, 
                user.Salt4, 
                user.Password);
            
            return verified 
                ? user.ToUserResponse() 
                : Result.NotFound("Wrong username or password");
        }
        
        return Result.NotFound("Wrong username or password");
    }
}
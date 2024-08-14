using Dotnetstore.Intranet.Organization.Users.Create;

namespace Dotnetstore.Intranet.Organization.Users;

internal sealed class UserService(IOrganizationUnitOfWork unitOfWork, IUserRepository repository) : IUserService
{
    async ValueTask<ErrorOr<UserResponse>> IUserService.CreateAsync(
        CreateUserRequest request, CancellationToken cancellationToken)
    {
        var existingUser = await repository.GetByUsernameAsync(request.Username, cancellationToken);

        if (existingUser is not null)
            return Error.Conflict("User already exists");

        var user = CreateUserBuilder.CreateNewUser()
            .CreateUserId()
            .SetPersonalData(request)
            .SetCredentials(request)
            .SetMetaData()
            .Build();
        
        repository.Create(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return user.ToUserResponse();
    }
}
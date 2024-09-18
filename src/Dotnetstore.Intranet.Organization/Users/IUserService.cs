using Ardalis.Result;
using SDK.Dto.Organization.Users.Requests;
using SDK.Dto.Organization.Users.Responses;

namespace Dotnetstore.Intranet.Organization.Users;

internal interface IUserService
{
    ValueTask<IEnumerable<UserResponse>> GetAllAsync(CancellationToken cancellationToken);
    
    ValueTask<IEnumerable<UserResponse>> GetAllNotDeletedAsync(CancellationToken cancellationToken);
    
    ValueTask<Result<UserResponse>> CreateAsync(UserCreateRequest request, CancellationToken cancellationToken);
    
    ValueTask<Result<UserResponse>> LoginAsync(UserLoginRequest request, CancellationToken cancellationToken);
}
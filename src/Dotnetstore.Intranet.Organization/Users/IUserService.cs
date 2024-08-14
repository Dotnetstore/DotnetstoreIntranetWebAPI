namespace Dotnetstore.Intranet.Organization.Users;

internal interface IUserService
{
    ValueTask<ErrorOr<UserResponse>> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken);
}
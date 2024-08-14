namespace Dotnetstore.Intranet.Organization.Users;

internal interface IUserRepository
{
    ValueTask<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
    
    void Create(User user);
}
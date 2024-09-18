namespace Dotnetstore.Intranet.Organization.Users;

internal interface IUserRepository
{
    ValueTask<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken);
    
    ValueTask<List<User>> GetAllNonSystemAsync(CancellationToken cancellationToken);
    
    ValueTask<IEnumerable<User>> GetAllNotDeletedAsync(CancellationToken cancellationToken);
    
    ValueTask<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
    
    ValueTask<User?> GetByIdAsync(UserId userId, CancellationToken cancellationToken);
    
    void Create(User user);
}
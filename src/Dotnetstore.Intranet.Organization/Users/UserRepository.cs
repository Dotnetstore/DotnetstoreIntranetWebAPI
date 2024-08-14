namespace Dotnetstore.Intranet.Organization.Users;

internal sealed class UserRepository(IOrganizationUnitOfWork unitOfWork) : IUserRepository
{
    async ValueTask<User?> IUserRepository.GetByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        return await unitOfWork
            .Repository<User>()
            .Entities
            .Where(q => q.Username == username)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    void IUserRepository.Create(User user)
    {
        unitOfWork.Repository<User>().Create(user);
    }
}
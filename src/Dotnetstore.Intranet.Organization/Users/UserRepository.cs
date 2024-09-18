namespace Dotnetstore.Intranet.Organization.Users;

internal sealed class UserRepository(IOrganizationUnitOfWork unitOfWork) : IUserRepository
{
    private IQueryable<User> GetUserQuery()
    {
        return unitOfWork
            .Repository<User>()
            .Entities
            .Include(x => x.UserInUserGroups)
            .ThenInclude(x => x.UserGroup)
            .ThenInclude(x => x.UserRoleInUserGroups)
            .ThenInclude(x => x.UserRole)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
            .Include(x => x.UserInUserRoles)
            .ThenInclude(x => x.UserRole)
            .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
            .ThenBy(x => x.MiddleName)
            .ThenBy(x => x.EnglishName)
            .ThenBy(x => x.SocialSecurityNumber);
    }
    
    async ValueTask<IEnumerable<User>> IUserRepository.GetAllAsync(CancellationToken cancellationToken)
    {
        var query = GetUserQuery();
        
        return await query
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);
    }

    async ValueTask<List<User>> IUserRepository.GetAllNonSystemAsync(CancellationToken cancellationToken)
    {
        var query = GetUserQuery();
        
        return await query
            .AsNoTracking()
            .Where(x => !x.IsSystem)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    async ValueTask<IEnumerable<User>> IUserRepository.GetAllNotDeletedAsync(CancellationToken cancellationToken)
    {
        var query = GetUserQuery();
        
        return await query
            .AsNoTracking()
            .Where(x => !x.IsDeleted)
            .Where(x => !x.IsSystem)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    async ValueTask<User?> IUserRepository.GetByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        var query = GetUserQuery();

        return await query
            .Where(x => x.Username == username)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public async ValueTask<User?> GetByIdAsync(UserId userId, CancellationToken cancellationToken)
    {
        var query = GetUserQuery();

        return await query
            .Where(x => x.UserId == userId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    void IUserRepository.Create(User user)
    {
        unitOfWork.Repository<User>().Create(user);
    }
}
using Dotnetstore.Intranet.Organization.EmailVerificationTokens;
using Dotnetstore.Intranet.Organization.UserGroups;
using Dotnetstore.Intranet.Organization.UserInUserGroups;
using Dotnetstore.Intranet.Organization.UserInUserRoles;
using Dotnetstore.Intranet.Organization.UserRoles;
using Dotnetstore.Intranet.Organization.UserRolesInUserGroups;

namespace Dotnetstore.Intranet.Organization;

internal sealed class OrganizationDataContext(DbContextOptions<OrganizationDataContext> options) : ApiContext<OrganizationDataContext>(options)
{
    internal DbSet<EmailVerificationToken> EmailVerificationTokens => Set<EmailVerificationToken>();
    
    internal DbSet<UserGroup> UserGroups => Set<UserGroup>();
    
    internal DbSet<UserInUserGroup> UserInUserGroups => Set<UserInUserGroup>();
    
    internal DbSet<UserInUserRole> UserInUserRoles => Set<UserInUserRole>();
    
    internal DbSet<UserRole> UserRoles => Set<UserRole>();
    
    internal DbSet<UserRoleInUserGroup> UserRoleInUserGroups => Set<UserRoleInUserGroup>();
    
    internal DbSet<User> Users => Set<User>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.HasDefaultSchema("Organization");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IOrganizationAssemblyMarker).Assembly);
    }
}
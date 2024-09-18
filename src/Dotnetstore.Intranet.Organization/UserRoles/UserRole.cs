using Dotnetstore.Intranet.Organization.UserInUserRoles;
using Dotnetstore.Intranet.Organization.UserRolesInUserGroups;

namespace Dotnetstore.Intranet.Organization.UserRoles;

internal sealed class UserRole : BaseAuditableEntity
{
    public UserRoleId UserRoleId { get; set; }

    public string Name { get; set; } = null!;
    
    public ICollection<UserRoleInUserGroup> UserRoleInUserGroups { get; set; } = new List<UserRoleInUserGroup>();
    
    public ICollection<UserInUserRole> UserInUserRoles { get; set; } = new List<UserInUserRole>();
}

internal record struct UserRoleId(Guid Id);
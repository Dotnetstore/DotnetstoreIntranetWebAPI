using Dotnetstore.Intranet.Organization.UserInUserGroups;
using Dotnetstore.Intranet.Organization.UserRolesInUserGroups;

namespace Dotnetstore.Intranet.Organization.UserGroups;

internal sealed class UserGroup : BaseAuditableEntity
{
    public UserGroupId UserGroupId { get; set; }

    public string Name { get; set; } = null!;
    
    public ICollection<UserRoleInUserGroup> UserRoleInUserGroups { get; set; } = new List<UserRoleInUserGroup>();
    
    public ICollection<UserInUserGroup> UserInUserGroups { get; set; } = new List<UserInUserGroup>();
}

internal record struct UserGroupId(Guid Id);
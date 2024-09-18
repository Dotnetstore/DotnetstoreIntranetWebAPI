using Dotnetstore.Intranet.Organization.UserGroups;
using Dotnetstore.Intranet.Organization.UserRoles;

namespace Dotnetstore.Intranet.Organization.UserRolesInUserGroups;

internal sealed class UserRoleInUserGroup : BaseAuditableEntity
{
    public UserRoleInUserGroupId UserRoleInUserGroupId { get; set; }

    public UserRoleId UserRoleId { get; set; }
    
    public UserGroupId UserGroupId { get; set; }

    public UserGroup UserGroup { get; set; } = null!;
    
    public UserRole UserRole { get; set; } = null!;
}

internal record struct UserRoleInUserGroupId(Guid Id);
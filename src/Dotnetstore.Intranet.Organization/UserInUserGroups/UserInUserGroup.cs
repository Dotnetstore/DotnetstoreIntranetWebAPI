using Dotnetstore.Intranet.Organization.UserGroups;

namespace Dotnetstore.Intranet.Organization.UserInUserGroups;

internal sealed class UserInUserGroup : BaseAuditableEntity
{
    public UserInUserGroupId Id { get; set; }

    public UserId UserId { get; set; }

    public UserGroupId UserGroupId { get; set; }

    public User User { get; set; } = null!;

    public UserGroup UserGroup { get; set; } = null!;
}

internal record struct UserInUserGroupId(Guid Value);
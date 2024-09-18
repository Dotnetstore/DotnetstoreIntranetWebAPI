using Dotnetstore.Intranet.Organization.EmailVerificationTokens;
using Dotnetstore.Intranet.Organization.UserInUserGroups;
using Dotnetstore.Intranet.Organization.UserInUserRoles;

namespace Dotnetstore.Intranet.Organization.Users;

internal sealed class User : Identity
{
    public UserId UserId { get; set; }

    public ICollection<EmailVerificationToken> EmailVerificationTokens { get; set; } = new List<EmailVerificationToken>();
    
    public ICollection<UserInUserRole> UserInUserRoles { get; set; } = new List<UserInUserRole>();
    
    public ICollection<UserInUserGroup> UserInUserGroups { get; set; } = new List<UserInUserGroup>();
}

internal record struct UserId(Guid Value);
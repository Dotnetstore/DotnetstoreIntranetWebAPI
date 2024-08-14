namespace Dotnetstore.Intranet.Organization.Users;

internal sealed class User : Identity
{
    public UserId UserId { get; set; }
}

internal record struct UserId(Guid Id);
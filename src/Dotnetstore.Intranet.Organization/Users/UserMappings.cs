namespace Dotnetstore.Intranet.Organization.Users;

internal static class UserMappings
{
    internal static UserResponse ToUserResponse(this User user)
    {
        return new UserResponse(
            user.UserId.Id,
            user.LastName,
            user.FirstName,
            user.MiddleName,
            user.EnglishName,
            user.SocialSecurityNumber,
            user.DateOfBirth,
            user.IsMale,
            user.LastNameFirst,
            user.IsBlocked,
            user.IsDeleted);
    }
}
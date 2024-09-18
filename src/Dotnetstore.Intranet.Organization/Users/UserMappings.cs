using SDK.Dto.Organization.Users.Responses;

namespace Dotnetstore.Intranet.Organization.Users;

internal static class UserMappings
{
    internal static UserResponse ToUserResponse(this User user)
    {
        var userGroups = user.UserInUserGroups.Select(x => x.UserGroup.Name).ToList();
        var userRoles = GetUserRoles(user);
        
        return new UserResponse(
            user.UserId.Value,
            user.LastName,
            user.FirstName,
            user.MiddleName,
            user.EnglishName,
            user.SocialSecurityNumber,
            user.DateOfBirth,
            user.IsMale,
            user.LastNameFirst,
            user.IsBlocked,
            user.IsDeleted,
            userGroups,
            userRoles);
    }
    
    private static List<string> GetUserRoles(User user)
    {
        var userRoles = user.UserInUserRoles.Select(x => x.UserRole.Name).ToList();
        
        var userRolesFromUserGroups = user.UserInUserGroups
            .SelectMany(x => x.UserGroup.UserRoleInUserGroups)
            .Select(x => x.UserRole.Name)
            .ToList();
        userRoles.AddRange(userRolesFromUserGroups);
        
        return userRoles.Distinct().ToList();
    }
}
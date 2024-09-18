namespace Dotnetstore.Intranet.Utility;

public static class Constants
{
    public const int DefaultNameLength = 50;
    public const int DefaultSocialSecurityNumberLength = 30;
    public const int DefaultUsernameLength = 255;
    public const int DefaultPasswordLength = 500;
    public const int DefaultSaltLength = 500;
    
    public static Guid UserGroupAdministratorsId = new("DBC442BE-1369-4ECA-94DE-87DC8A62978D");
    public static Guid UserGroupSuperUsersId = new("C860A6D5-AA70-432E-BBC9-4A301325C4A2");
    public static Guid UserGroupUsersId = new("0FBD1DE8-516F-4BCB-B5E6-80A7DC1D4603");
    
    public static Guid UserRoleAdministratorId = new("DF05ADF2-5761-4B92-8C4A-EAA95E446E17");
    public static Guid UserRoleSuperUserId = new("20B5AC29-256A-43B1-9BAA-BB00BD9509AF");
    public static Guid UserRoleUserId = new("145B09DF-8835-4665-BB1B-577A11009849");
    
    public static Guid SystemUserId = new("A105BB00-6144-4C57-B10A-389319089BFA");
}
using SDK.Dto.Organization.Users.Requests;

namespace Dotnetstore.Intranet.Organization.Users.Create;

internal sealed class CreateUserBuilder : 
    ICreateUserId,
    ICreateUserObject,
    ISetCredentials,
    ISetMetaData,
    IBuildUser
{
    private UserId _userId;
    private string _username = null!;
    private string _password = null!;
    private string _salt1 = null!;
    private string _salt2 = null!;
    private string _salt3 = null!;
    private string _salt4 = null!;
    private bool _isBlocked;
    private DateTimeOffset? _blockedDate;
    private string _lastName = null!;
    private string _firstName = null!;
    private string? _middleName;
    private string? _englishName;
    private string? _socialSecurityNumber;
    private DateTime? _dateOfBirth;
    private bool _isMale;
    private bool _lastNameFirst;
    private Guid? _createdBy;
    private DateTimeOffset _createdDate;
    private Guid? _lastUpdatedBy;
    private DateTimeOffset? _lastUpdatedDate;
    private bool _isDeleted;
    private Guid? _deletedBy;
    private DateTimeOffset? _deletedDate;
    private bool _isSystem;
    private bool _isGdpr;

    private CreateUserBuilder()
    {
    }

    internal static ICreateUserId CreateNewUser()
    {
        return new CreateUserBuilder();
    }
    
    ICreateUserObject ICreateUserId.CreateUserId()
    {
        _userId = new UserId(Guid.NewGuid());
        return this;
    }

    ISetCredentials ICreateUserObject.SetPersonalData(UserCreateRequest request)
    {
        _lastName = request.LastName;
        _firstName = request.FirstName;
        _middleName = request.MiddleName;
        _englishName = request.EnglishName;
        _socialSecurityNumber = request.SocialSecurityNumber;
        _dateOfBirth = request.DateOfBirth;
        _isMale = request.IsMale;
        _lastNameFirst = request.LastNameFirst;
        
        return this;
    }

    ISetMetaData ISetCredentials.SetCredentials(UserCreateRequest request)
    {
        _salt1 = StringService.RandomString(300);
        _salt2 = StringService.RandomString(300);
        _salt3 = StringService.RandomString(300);
        _salt4 = StringService.RandomString(300);
        
        var hashedPassword = request.Password.Hash(_salt1, _salt2, _salt3, _salt4);
        
        _username = Guard.Against.NullOrWhiteSpace(request.Username, nameof(request.Username));
        _password = Guard.Against.NullOrWhiteSpace(hashedPassword, nameof(hashedPassword));

        return this;
    }

    IBuildUser ISetMetaData.SetMetaData(
        Guid? createdBy,
        bool isSystem,
        bool isGdpr)
    {
        _isBlocked = false;
        _blockedDate = null;
        _createdBy = createdBy;
        _createdDate = DateTimeOffset.Now;
        _lastUpdatedBy = null;
        _lastUpdatedDate = null;
        _isDeleted = false;
        _deletedBy = null;
        _deletedDate = null;
        _isSystem = isSystem;
        _isGdpr = isGdpr;

        return this;
    }

    User IBuildUser.Build()
    {
        return UserBuilder.Create()
            .WithUserId(_userId)
            .WithUsername(_username)
            .WithPassword(_password)
            .WithSalt1(_salt1)
            .WithSalt2(_salt2)
            .WithSalt3(_salt3)
            .WithSalt4(_salt4)
            .WithIsBlocked(_isBlocked)
            .WithBlockedDate(_blockedDate)
            .WithLastName(_lastName)
            .WithFirstName(_firstName)
            .WithMiddleName(_middleName)
            .WithEnglishName(_englishName)
            .WithSocialSecurityNumber(_socialSecurityNumber)
            .WithDateOfBirth(_dateOfBirth)
            .WithIsMale(_isMale)
            .WithLastNameFirst(_lastNameFirst)
            .WithCreatedBy(_createdBy)
            .WithCreatedDate(_createdDate)
            .WithLastUpdatedBy(_lastUpdatedBy)
            .WithLastUpdatedDate(_lastUpdatedDate)
            .WithIsDeleted(_isDeleted)
            .WithDeletedBy(_deletedBy)
            .WithDeletedDate(_deletedDate)
            .WithIsSystem(_isSystem)
            .WithIsGdpr(_isGdpr)
            .Build();
    }
}

internal interface ICreateUserId
{
    ICreateUserObject CreateUserId();
}

internal interface ICreateUserObject
{
    ISetCredentials SetPersonalData(UserCreateRequest request);
}

internal interface ISetCredentials
{
    ISetMetaData SetCredentials(UserCreateRequest request);
}

internal interface ISetMetaData
{
    IBuildUser SetMetaData(
        Guid? createdBy = null,
        bool isSystem = false,
        bool isGdpr = false);
}

internal interface IBuildUser
{
    User Build();
}
namespace Dotnetstore.Intranet.Organization.Users;

internal sealed class UserBuilder
{
    private UserId UserId { get; set; }
    private string Username { get; set; } = null!;
    private string Password { get; set; } = null!;
    private string Salt1 { get; set; } = null!;
    private string Salt2 { get; set; } = null!;
    private string Salt3 { get; set; } = null!;
    private string Salt4 { get; set; } = null!;
    private bool IsBlocked { get; set; }
    private DateTimeOffset? BlockedDate { get; set; }
    private string LastName { get; set; } = null!;
    private string FirstName { get; set; } = null!;
    private string? MiddleName { get; set; }
    private string? EnglishName { get; set; }
    private string? SocialSecurityNumber { get; set; }
    private DateTime? DateOfBirth { get; set; }
    private bool IsMale { get; set; }
    private bool LastNameFirst { get; set; }
    private Guid? CreatedBy { get; set; }
    private DateTimeOffset CreatedDate { get; set; }
    private Guid? LastUpdatedBy { get; set; }
    private DateTimeOffset? LastUpdatedDate { get; set; }
    private bool IsDeleted { get; set; }
    private Guid? DeletedBy { get; set; }
    private DateTimeOffset? DeletedDate { get; set; }
    private bool IsSystem { get; set; }
    private bool IsGdpr { get; set; }
    
    internal static UserBuilder Create()
    {
        return new UserBuilder();
    }
    
    internal UserBuilder WithUserId(UserId userId)
    {
        UserId = userId;
        return this;
    }
    
    internal UserBuilder WithUsername(string username)
    {
        Username = Guard.Against.NullOrEmpty(username, nameof(username));
        return this;
    }
    
    internal UserBuilder WithPassword(string password)
    {
        Password = Guard.Against.NullOrEmpty(password, nameof(password));
        return this;
    }
    
    internal UserBuilder WithSalt1(string salt1)
    {
        Salt1 = Guard.Against.NullOrEmpty(salt1, nameof(salt1));
        return this;
    }
    
    internal UserBuilder WithSalt2(string salt2)
    {
        Salt2 = Guard.Against.NullOrEmpty(salt2, nameof(salt2));
        return this;
    }
    
    internal UserBuilder WithSalt3(string salt3)
    {
        Salt3 = Guard.Against.NullOrEmpty(salt3, nameof(salt3));
        return this;
    }
    
    internal UserBuilder WithSalt4(string salt4)
    {
        Salt4 = Guard.Against.NullOrEmpty(salt4, nameof(salt4));
        return this;
    }
    
    internal UserBuilder WithIsBlocked(bool isBlocked)
    {
        IsBlocked = isBlocked;
        return this;
    }
    
    internal UserBuilder WithBlockedDate(DateTimeOffset? blockedDate)
    {
        BlockedDate = blockedDate;
        return this;
    }
    
    internal UserBuilder WithLastName(string lastName)
    {
        LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
        return this;
    }
    
    internal UserBuilder WithFirstName(string firstName)
    {
        FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
        return this;
    }
    
    internal UserBuilder WithMiddleName(string? middleName)
    {
        MiddleName = middleName;
        return this;
    }
    
    internal UserBuilder WithEnglishName(string? englishName)
    {
        EnglishName = englishName;
        return this;
    }
    
    internal UserBuilder WithSocialSecurityNumber(string? socialSecurityNumber)
    {
        SocialSecurityNumber = socialSecurityNumber;
        return this;
    }
    
    internal UserBuilder WithDateOfBirth(DateTime? dateOfBirth)
    {
        DateOfBirth = dateOfBirth;
        return this;
    }
    
    internal UserBuilder WithIsMale(bool isMale)
    {
        IsMale = isMale;
        return this;
    }
    
    internal UserBuilder WithLastNameFirst(bool lastNameFirst)
    {
        LastNameFirst = lastNameFirst;
        return this;
    }
    
    internal UserBuilder WithCreatedBy(Guid? createdBy)
    {
        CreatedBy = createdBy;
        return this;
    }
    
    internal UserBuilder WithCreatedDate(DateTimeOffset createdDate)
    {
        CreatedDate = createdDate;
        return this;
    }
    
    internal UserBuilder WithLastUpdatedBy(Guid? lastUpdatedBy)
    {
        LastUpdatedBy = lastUpdatedBy;
        return this;
    }
    
    internal UserBuilder WithLastUpdatedDate(DateTimeOffset? lastUpdatedDate)
    {
        LastUpdatedDate = lastUpdatedDate;
        return this;
    }
    
    internal UserBuilder WithIsDeleted(bool isDeleted)
    {
        IsDeleted = isDeleted;
        return this;
    }
    
    internal UserBuilder WithDeletedBy(Guid? deletedBy)
    {
        DeletedBy = deletedBy;
        return this;
    }
    
    internal UserBuilder WithDeletedDate(DateTimeOffset? deletedDate)
    {
        DeletedDate = deletedDate;
        return this;
    }
    
    internal UserBuilder WithIsSystem(bool isSystem)
    {
        IsSystem = isSystem;
        return this;
    }
    
    internal UserBuilder WithIsGdpr(bool isGdpr)
    {
        IsGdpr = isGdpr;
        return this;
    }
    
    internal User Build()
    {
        return new User
        {
            UserId = UserId,
            Username = Username,
            Password = Password,
            Salt1 = Salt1,
            Salt2 = Salt2,
            Salt3 = Salt3,
            Salt4 = Salt4,
            IsBlocked = IsBlocked,
            BlockedDate = BlockedDate,
            LastName = LastName,
            FirstName = FirstName,
            MiddleName = MiddleName,
            EnglishName = EnglishName,
            SocialSecurityNumber = SocialSecurityNumber,
            DateOfBirth = DateOfBirth,
            IsMale = IsMale,
            LastNameFirst = LastNameFirst,
            CreatedBy = CreatedBy,
            CreatedDate = CreatedDate,
            LastUpdatedBy = LastUpdatedBy,
            LastUpdatedDate = LastUpdatedDate,
            IsDeleted = IsDeleted,
            DeletedBy = DeletedBy,
            DeletedDate = DeletedDate,
            IsSystem = IsSystem,
            IsGdpr = IsGdpr
        };
    }
}
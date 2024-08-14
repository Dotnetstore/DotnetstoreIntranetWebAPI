using Dotnetstore.Intranet.Organization.Users;

namespace Dotnetstore.Intranet.Organization.Test.TestData;

internal sealed class UserTestData
{
    internal static User CreateTestUser(
        string lastName = "Testsson",
        string firstName = "Test",
        string middleName = "Testar",
        string englishName = "Testing",
        string socialSecurityNumber = "1234567890",
        DateTime? dateOfBirth = null,
        bool isMale = true,
        bool lastNameFirst = true,
        string username = "test@test.com",
        string password = "password")
    {
        return new UserBuilder()
            .WithUserId(new UserId(Guid.NewGuid()))
            .WithLastName(lastName)
            .WithFirstName(firstName)
            .WithMiddleName(middleName)
            .WithEnglishName(englishName)
            .WithSocialSecurityNumber(socialSecurityNumber)
            .WithDateOfBirth(dateOfBirth)
            .WithIsMale(isMale)
            .WithLastNameFirst(lastNameFirst)
            .WithUsername(username)
            .WithPassword(password)
            .WithSalt1("TestSalt1")
            .WithSalt2("TestSalt1")
            .WithSalt3("TestSalt1")
            .WithSalt4("TestSalt1")
            .WithCreatedDate(DateTimeOffset.Now)
            .Build();
    }
}
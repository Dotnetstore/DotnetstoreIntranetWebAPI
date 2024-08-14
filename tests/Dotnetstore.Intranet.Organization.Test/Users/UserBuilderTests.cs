using Dotnetstore.Intranet.Organization.Users;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.Organization.Test.Users;

public class UserBuilderTests
{
    [Fact]
    public void Test_Create_ReturnsUserBuilder()
    {
        var builder = UserBuilder.Create();
        builder.Should().NotBeNull();
        builder.Should().BeOfType<UserBuilder>();
    }

    [Fact]
    public void Test_WithUserId_SetsUserId()
    {
        var userId = new UserId(Guid.NewGuid());
        var builder = UserBuilder.Create().WithUserId(userId);
        var user = builder.Build();
        user.UserId.Should().Be(userId);
    }

    [Fact]
    public void Test_WithUsername_SetsUsername()
    {
        var username = "testuser";
        var builder = UserBuilder.Create().WithUsername(username);
        var user = builder.Build();
        user.Username.Should().Be(username);
    }

    [Fact]
    public void Test_WithPassword_SetsPassword()
    {
        var password = "password123";
        var builder = UserBuilder.Create().WithPassword(password);
        var user = builder.Build();
        user.Password.Should().Be(password);
    }

    [Fact]
    public void Test_WithSalt1_SetsSalt1()
    {
        var salt1 = "salt1";
        var builder = UserBuilder.Create().WithSalt1(salt1);
        var user = builder.Build();
        user.Salt1.Should().Be(salt1);
    }

    [Fact]
    public void Test_WithSalt2_SetsSalt2()
    {
        var salt2 = "salt2";
        var builder = UserBuilder.Create().WithSalt2(salt2);
        var user = builder.Build();
        user.Salt2.Should().Be(salt2);
    }

    [Fact]
    public void Test_WithSalt3_SetsSalt3()
    {
        var salt3 = "salt3";
        var builder = UserBuilder.Create().WithSalt3(salt3);
        var user = builder.Build();
        user.Salt3.Should().Be(salt3);
    }

    [Fact]
    public void Test_WithSalt4_SetsSalt4()
    {
        var salt4 = "salt4";
        var builder = UserBuilder.Create().WithSalt4(salt4);
        var user = builder.Build();
        user.Salt4.Should().Be(salt4);
    }

    [Fact]
    public void Test_WithIsBlocked_SetsIsBlocked()
    {
        var builder = UserBuilder.Create().WithIsBlocked(true);
        var user = builder.Build();
        user.IsBlocked.Should().BeTrue();
    }

    [Fact]
    public void Test_WithBlockedDate_SetsBlockedDate()
    {
        var blockedDate = DateTimeOffset.UtcNow;
        var builder = UserBuilder.Create().WithBlockedDate(blockedDate);
        var user = builder.Build();
        user.BlockedDate.Should().Be(blockedDate);
    }

    [Fact]
    public void Test_WithLastName_SetsLastName()
    {
        var lastName = "Doe";
        var builder = UserBuilder.Create().WithLastName(lastName);
        var user = builder.Build();
        user.LastName.Should().Be(lastName);
    }

    [Fact]
    public void Test_WithFirstName_SetsFirstName()
    {
        var firstName = "John";
        var builder = UserBuilder.Create().WithFirstName(firstName);
        var user = builder.Build();
        user.FirstName.Should().Be(firstName);
    }

    [Fact]
    public void Test_WithMiddleName_SetsMiddleName()
    {
        var middleName = "A.";
        var builder = UserBuilder.Create().WithMiddleName(middleName);
        var user = builder.Build();
        user.MiddleName.Should().Be(middleName);
    }

    [Fact]
    public void Test_WithEnglishName_SetsEnglishName()
    {
        var englishName = "Johnny";
        var builder = UserBuilder.Create().WithEnglishName(englishName);
        var user = builder.Build();
        user.EnglishName.Should().Be(englishName);
    }

    [Fact]
    public void Test_WithSocialSecurityNumber_SetsSocialSecurityNumber()
    {
        var ssn = "123-45-6789";
        var builder = UserBuilder.Create().WithSocialSecurityNumber(ssn);
        var user = builder.Build();
        user.SocialSecurityNumber.Should().Be(ssn);
    }

    [Fact]
    public void Test_WithDateOfBirth_SetsDateOfBirth()
    {
        var dob = new DateTime(1990, 1, 1);
        var builder = UserBuilder.Create().WithDateOfBirth(dob);
        var user = builder.Build();
        user.DateOfBirth.Should().Be(dob);
    }

    [Fact]
    public void Test_WithIsMale_SetsIsMale()
    {
        var builder = UserBuilder.Create().WithIsMale(true);
        var user = builder.Build();
        user.IsMale.Should().BeTrue();
    }

    [Fact]
    public void Test_WithLastNameFirst_SetsLastNameFirst()
    {
        var builder = UserBuilder.Create().WithLastNameFirst(true);
        var user = builder.Build();
        user.LastNameFirst.Should().BeTrue();
    }

    [Fact]
    public void Test_WithCreatedBy_SetsCreatedBy()
    {
        var createdBy = Guid.NewGuid();
        var builder = UserBuilder.Create().WithCreatedBy(createdBy);
        var user = builder.Build();
        user.CreatedBy.Should().Be(createdBy);
    }

    [Fact]
    public void Test_WithCreatedDate_SetsCreatedDate()
    {
        var createdDate = DateTimeOffset.UtcNow;
        var builder = UserBuilder.Create().WithCreatedDate(createdDate);
        var user = builder.Build();
        user.CreatedDate.Should().Be(createdDate);
    }

    [Fact]
    public void Test_WithLastUpdatedBy_SetsLastUpdatedBy()
    {
        var lastUpdatedBy = Guid.NewGuid();
        var builder = UserBuilder.Create().WithLastUpdatedBy(lastUpdatedBy);
        var user = builder.Build();
        user.LastUpdatedBy.Should().Be(lastUpdatedBy);
    }

    [Fact]
    public void Test_WithLastUpdatedDate_SetsLastUpdatedDate()
    {
        var lastUpdatedDate = DateTimeOffset.UtcNow;
        var builder = UserBuilder.Create().WithLastUpdatedDate(lastUpdatedDate);
        var user = builder.Build();
        user.LastUpdatedDate.Should().Be(lastUpdatedDate);
    }

    [Fact]
    public void Test_WithIsDeleted_SetsIsDeleted()
    {
        var builder = UserBuilder.Create().WithIsDeleted(true);
        var user = builder.Build();
        user.IsDeleted.Should().BeTrue();
    }

    [Fact]
    public void Test_WithDeletedBy_SetsDeletedBy()
    {
        var deletedBy = Guid.NewGuid();
        var builder = UserBuilder.Create().WithDeletedBy(deletedBy);
        var user = builder.Build();
        user.DeletedBy.Should().Be(deletedBy);
    }

    [Fact]
    public void Test_WithDeletedDate_SetsDeletedDate()
    {
        var deletedDate = DateTimeOffset.UtcNow;
        var builder = UserBuilder.Create().WithDeletedDate(deletedDate);
        var user = builder.Build();
        user.DeletedDate.Should().Be(deletedDate);
    }

    [Fact]
    public void Test_WithIsSystem_SetsIsSystem()
    {
        var builder = UserBuilder.Create().WithIsSystem(true);
        var user = builder.Build();
        user.IsSystem.Should().BeTrue();
    }

    [Fact]
    public void Test_WithIsGdpr_SetsIsGdpr()
    {
        var builder = UserBuilder.Create().WithIsGdpr(true);
        var user = builder.Build();
        user.IsGdpr.Should().BeTrue();
    }
}
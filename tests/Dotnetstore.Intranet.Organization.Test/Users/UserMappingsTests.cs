using Dotnetstore.Intranet.Organization.Users;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.Organization.Test.Users;

public class UserMappingsTests
{
    [Fact]
    public void Test_ToUserResponse_MapsCorrectly()
    {
        var userId = new UserId(Guid.NewGuid());
        var user = new User
        {
            UserId = userId,
            LastName = "Doe",
            FirstName = "John",
            MiddleName = "A.",
            EnglishName = "Johnny",
            SocialSecurityNumber = "123-45-6789",
            DateOfBirth = new DateTime(1990, 1, 1),
            IsMale = true,
            LastNameFirst = true,
            IsBlocked = false,
            IsDeleted = false
        };

        var response = user.ToUserResponse();

        response.Id.Should().Be(userId.Id);
        response.LastName.Should().Be("Doe");
        response.FirstName.Should().Be("John");
        response.MiddleName.Should().Be("A.");
        response.EnglishName.Should().Be("Johnny");
        response.SocialSecurityNumber.Should().Be("123-45-6789");
        response.DateOfBirth.Should().Be(new DateTime(1990, 1, 1));
        response.IsMale.Should().BeTrue();
        response.LastNameFirst.Should().BeTrue();
        response.IsBlocked.Should().BeFalse();
        response.IsDeleted.Should().BeFalse();
    }
}
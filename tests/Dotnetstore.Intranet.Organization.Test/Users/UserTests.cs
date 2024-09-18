using Dotnetstore.Intranet.Organization.Users;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.Organization.Test.Users;

public class UserTests
{
    [Fact]
    public void User_ShouldContainCorrectProperties()
    {
        // Arrange
        var id = Guid.NewGuid();
        var user = new User { UserId = new UserId(id)};

        // Act
        var userId = user.UserId;

        // Assert
        userId.Value.Should().Be(id);
    }
}
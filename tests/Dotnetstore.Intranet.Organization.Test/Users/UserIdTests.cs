using Dotnetstore.Intranet.Organization.Users;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.Organization.Test.Users;

public class UserIdTests
{
    [Fact]
    public void UserId_ShouldContainCorrectProperties()
    {
        // Arrange
        var id = Guid.NewGuid();
        
        // Act
        var userId = new UserId(id);

        // Assert
        userId.Id.Should().Be(id);
    }
}
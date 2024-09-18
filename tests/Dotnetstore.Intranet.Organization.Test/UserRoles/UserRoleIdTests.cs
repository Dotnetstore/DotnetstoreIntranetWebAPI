using Dotnetstore.Intranet.Organization.UserRoles;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.Organization.Test.UserRoles;

public class UserRoleIdTests
{
    [Fact]
    public void UserRoleId_ShouldContainCorrectProperties()
    {
        // Arrange
        var id = Guid.NewGuid();
        
        // Act
        var userId = new UserRoleId(id);

        // Assert
        userId.Id.Should().Be(id);
    }
}
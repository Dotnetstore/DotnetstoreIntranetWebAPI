using Dotnetstore.Intranet.Organization.UserRoles;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.Intranet.Organization.Test.UserRoles;

public class UserRoleTests
{
    [Fact]
    public void UserRole_ShouldContainCorrectProperties()
    {
        // Arrange
        var id = Guid.NewGuid();
        const string name = "Test";

        // Act
        var user = new UserRole { UserRoleId = new UserRoleId(id), Name = name};

        // Assert
        using (new AssertionScope())
        {
            user.UserRoleId.Id.Should().Be(id);
            user.Name.Should().Be(name);
        }
    }
}
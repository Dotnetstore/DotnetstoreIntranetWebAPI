using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.Intranet.Email.Contracts.Test;

public class SendNewRegistrationEmailCommandTests
{
    [Fact]
    public void SendNewRegistrationEmailCommand_WhenCreated_ShouldHaveCorrectProperties()
    {
        // Arrange
        const string lastName = "Doe";
        const string firstName = "John";
        const bool lastNameFirst = true;
        const string email = "test@test.com";

        // Act
        var command = new SendNewRegistrationEmailCommand(lastName, firstName, lastNameFirst, email);

        // Assert
        using (new AssertionScope())
        {
            command.LastName.Should().Be(lastName);
            command.FirstName.Should().Be(firstName);
            command.LastNameFirst.Should().Be(lastNameFirst);
            command.Email.Should().Be(email);
        }
    }
}
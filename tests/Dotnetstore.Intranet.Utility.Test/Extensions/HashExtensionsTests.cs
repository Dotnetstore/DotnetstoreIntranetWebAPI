using Dotnetstore.Intranet.Utility.Extensions;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.Utility.Test.Extensions;

public class HashExtensionsTests
{
    private const string Password = "password";
    private const string Salt1 = "salt1";
    private const string Salt2 = "salt2";
    private const string Salt3 = "salt3";
    private const string Salt4 = "salt4";
    private const string HashedValue = "F544A9ABA84ED34554C729544BBC4F8CCD30745CC287DE7C7DC6E15E98371DD876EF21B225A6A710762FC5BF0F9B73F5AC6995AECC10AF34B85F1C90456789D1-0359BDCEF3D1D91496FEA715C8380C777C16765154970C6A14843C174BDE974B";

    [Fact]
    public void Hash_WhenCalled_ReturnsHashedValue()
    {
        // Act
        var result = Password.Hash(Salt1, Salt2, Salt3, Salt4);

        // Assert
        result.Should().NotBeEmpty();
    }
    
    [Fact]
    public void Verify_WhenCalledWithCorrectPassword_ReturnsTrue()
    {
        // Act
        var result = Password.Verify(Salt1, Salt2, Salt3, Salt4, HashedValue);

        // Assert
        result.Should().BeTrue();
    }
    
    [Fact]
    public void Verify_WhenCalledWithIncorrectPassword_ReturnsFalse()
    {
        // Arrange
        const string incorrectPassword = "incorrectPassword";

        // Act
        var result = incorrectPassword.Verify(Salt1, Salt2, Salt3, Salt4, HashedValue);

        // Assert
        result.Should().BeFalse();
    }
}
using System.ComponentModel.DataAnnotations;
using System.Security;
using Dotnetstore.Intranet.Utility.Services;
using Dotnetstore.Intranet.Utility.Validations;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.Utility.Test.Validations;

public class PasswordValidationTests
{
    private class TestModel
    {
        public SecureString? Password { get; set; }
        public SecureString? ConfirmPassword { get; set; }
    }

    private ValidationContext CreateValidationContext(TestModel model)
    {
        return new ValidationContext(model);
    }

    [Fact]
    public void Should_Return_Success_When_Passwords_Match()
    {
        // Arrange
        var model = new TestModel
        {
            Password = "password".ToSecureString(),
            ConfirmPassword = "password".ToSecureString()
        };
        var validationContext = CreateValidationContext(model);
        var validationAttribute = new PasswordValidation(nameof(TestModel.Password), nameof(TestModel.ConfirmPassword));

        // Act
        var result = validationAttribute.GetValidationResult(null, validationContext);

        // Assert
        result.Should().Be(ValidationResult.Success);
    }

    [Fact]
    public void Should_Return_Error_When_Passwords_Do_Not_Match()
    {
        // Arrange
        var model = new TestModel
        {
            Password = "password".ToSecureString(),
            ConfirmPassword = "different".ToSecureString()
        };
        var validationContext = CreateValidationContext(model);
        var validationAttribute = new PasswordValidation(nameof(TestModel.Password), nameof(TestModel.ConfirmPassword));

        // Act
        var result = validationAttribute.GetValidationResult(null, validationContext);

        // Assert
        result.Should().NotBe(ValidationResult.Success);
        result!.ErrorMessage.Should().Be("Password and ConfirmPassword do not match");
    }

    [Fact]
    public void Should_Return_Error_When_Password_Is_Null()
    {
        // Arrange
        var model = new TestModel
        {
            Password = null,
            ConfirmPassword = "password".ToSecureString()
        };
        var validationContext = CreateValidationContext(model);
        var validationAttribute = new PasswordValidation(nameof(TestModel.Password), nameof(TestModel.ConfirmPassword));

        // Act
        var result = validationAttribute.GetValidationResult(null, validationContext);

        // Assert
        result.Should().NotBe(ValidationResult.Success);
        result!.ErrorMessage.Should().Be("Password or ConfirmPassword is null");
    }

    [Fact]
    public void Should_Return_Error_When_ConfirmPassword_Is_Null()
    {
        // Arrange
        var model = new TestModel
        {
            Password = "password".ToSecureString(),
            ConfirmPassword = null
        };
        var validationContext = CreateValidationContext(model);
        var validationAttribute = new PasswordValidation(nameof(TestModel.Password), nameof(TestModel.ConfirmPassword));

        // Act
        var result = validationAttribute.GetValidationResult(null, validationContext);

        // Assert
        result.Should().NotBe(ValidationResult.Success);
        result!.ErrorMessage.Should().Be("Password or ConfirmPassword is null");
    }

    [Fact]
    public void Should_Return_Error_When_Password_Is_Empty()
    {
        // Arrange
        var model = new TestModel
        {
            Password = "".ToSecureString(),
            ConfirmPassword = "".ToSecureString()
        };
        var validationContext = CreateValidationContext(model);
        var validationAttribute = new PasswordValidation(nameof(TestModel.Password), nameof(TestModel.ConfirmPassword));

        // Act
        var result = validationAttribute.GetValidationResult(null, validationContext);

        // Assert
        result.Should().NotBe(ValidationResult.Success);
        result!.ErrorMessage.Should().Be("Password is empty");
    }
}
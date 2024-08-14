using Dotnetstore.Intranet.Organization.Users.Create;
using FluentValidation.TestHelper;
using SDK.Dto.Users.Requests;
using Xunit;

namespace Dotnetstore.Intranet.Organization.Test.Users.Create;

public class CreateUserRequestValidatorTests
{
    private readonly CreateUserRequestValidator _validatorTests = new();

    [Fact]
    public void Should_Have_Error_When_LastName_Is_Empty()
    {
        var model = new CreateUserRequest { LastName = string.Empty };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.LastName);
    }

    [Fact]
    public void Should_Have_Error_When_LastName_Exceeds_MaxLength()
    {
        var model = new CreateUserRequest { LastName = new string('a', 51) };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.LastName);
    }

    [Fact]
    public void Should_Have_Error_When_FirstName_Is_Empty()
    {
        var model = new CreateUserRequest { FirstName = string.Empty };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.FirstName);
    }

    [Fact]
    public void Should_Have_Error_When_FirstName_Exceeds_MaxLength()
    {
        var model = new CreateUserRequest { FirstName = new string('a', 51) };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.FirstName);
    }

    [Fact]
    public void Should_Have_Error_When_MiddleName_Exceeds_MaxLength()
    {
        var model = new CreateUserRequest { MiddleName = new string('a', 51) };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.MiddleName);
    }

    [Fact]
    public void Should_Have_Error_When_EnglishName_Exceeds_MaxLength()
    {
        var model = new CreateUserRequest { EnglishName = new string('a', 51) };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.EnglishName);
    }

    [Fact]
    public void Should_Have_Error_When_SocialSecurityNumber_Exceeds_MaxLength()
    {
        var model = new CreateUserRequest { SocialSecurityNumber = new string('a', 51) };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.SocialSecurityNumber);
    }

    [Fact]
    public void Should_Have_Error_When_DateOfBirth_Is_In_The_Future()
    {
        var model = new CreateUserRequest { DateOfBirth = DateTime.Now.AddYears(1) };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.DateOfBirth);
    }

    [Fact]
    public void Should_Have_Error_When_Username_Is_Empty()
    {
        var model = new CreateUserRequest { Username = string.Empty };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Username);
    }

    [Fact]
    public void Should_Have_Error_When_Username_Exceeds_MaxLength()
    {
        var model = new CreateUserRequest { Username = new string('a', 51) };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Username);
    }

    [Fact]
    public void Should_Have_Error_When_Username_Is_Not_Valid_Email()
    {
        var model = new CreateUserRequest { Username = "invalid-email" };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Username);
    }

    [Fact]
    public void Should_Have_Error_When_Password_Is_Empty()
    {
        var model = new CreateUserRequest { Password = string.Empty };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void Should_Have_Error_When_Password_Exceeds_MaxLength()
    {
        var model = new CreateUserRequest { Password = new string('a', 51) };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void Should_Have_Error_When_ConfirmPassword_Is_Empty()
    {
        var model = new CreateUserRequest { ConfirmPassword = string.Empty };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.ConfirmPassword);
    }

    [Fact]
    public void Should_Have_Error_When_ConfirmPassword_Exceeds_MaxLength()
    {
        var model = new CreateUserRequest { ConfirmPassword = new string('a', 51) };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.ConfirmPassword);
    }

    [Fact]
    public void Should_Have_Error_When_Passwords_Do_Not_Match()
    {
        var model = new CreateUserRequest { Password = "password", ConfirmPassword = "different" };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.ConfirmPassword);
    }
}
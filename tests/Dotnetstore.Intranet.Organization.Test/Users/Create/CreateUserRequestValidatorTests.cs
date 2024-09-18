using Dotnetstore.Intranet.Organization.Users.Create;
using FluentValidation.TestHelper;
using SDK.Dto.Organization.Users.Requests;
using Xunit;

namespace Dotnetstore.Intranet.Organization.Test.Users.Create;

public class CreateUserRequestValidatorTests
{
    private readonly CreateUserRequestValidator _validatorTests = new();

    [Fact]
    public void Should_Have_Error_When_LastName_Is_Empty()
    {
        var model = new UserCreateRequest { LastName = string.Empty, Password = "password", ConfirmPassword = "different" };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.LastName);
    }

    [Fact]
    public void Should_Have_Error_When_LastName_Exceeds_MaxLength()
    {
        var model = new UserCreateRequest { LastName = new string('a', 51), Password = "password", ConfirmPassword = "different" };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.LastName);
    }

    [Fact]
    public void Should_Have_Error_When_FirstName_Is_Empty()
    {
        var model = new UserCreateRequest { FirstName = string.Empty, Password = "password", ConfirmPassword = "different" };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.FirstName);
    }

    [Fact]
    public void Should_Have_Error_When_FirstName_Exceeds_MaxLength()
    {
        var model = new UserCreateRequest { FirstName = new string('a', 51), Password = "password", ConfirmPassword = "different" };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.FirstName);
    }

    [Fact]
    public void Should_Have_Error_When_MiddleName_Exceeds_MaxLength()
    {
        var model = new UserCreateRequest { MiddleName = new string('a', 51), Password = "password", ConfirmPassword = "different" };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.MiddleName);
    }

    [Fact]
    public void Should_Have_Error_When_EnglishName_Exceeds_MaxLength()
    {
        var model = new UserCreateRequest { EnglishName = new string('a', 51), Password = "password", ConfirmPassword = "different" };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.EnglishName);
    }

    [Fact]
    public void Should_Have_Error_When_SocialSecurityNumber_Exceeds_MaxLength()
    {
        var model = new UserCreateRequest { SocialSecurityNumber = new string('a', 51), Password = "password", ConfirmPassword = "different" };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.SocialSecurityNumber);
    }

    [Fact]
    public void Should_Have_Error_When_DateOfBirth_Is_In_The_Future()
    {
        var model = new UserCreateRequest { DateOfBirth = DateTime.Now.AddYears(1), Password = "password", ConfirmPassword = "different" };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.DateOfBirth);
    }

    [Fact]
    public void Should_Have_Error_When_Username_Is_Empty()
    {
        var model = new UserCreateRequest { Username = string.Empty, Password = "password", ConfirmPassword = "different" };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Username);
    }

    [Fact]
    public void Should_Have_Error_When_Username_Exceeds_MaxLength()
    {
        var model = new UserCreateRequest { Username = new string('a', 51), Password = "password", ConfirmPassword = "different" };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Username);
    }

    [Fact]
    public void Should_Have_Error_When_Username_Is_Not_Valid_Email()
    {
        var model = new UserCreateRequest { Username = "invalid-email", Password = "password", ConfirmPassword = "different" };
        var result = _validatorTests.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Username);
    }
}
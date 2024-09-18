using SDK.Dto.Organization.Users.Requests;

namespace Dotnetstore.Intranet.Organization.Users.Create;

internal sealed class CreateUserRequestValidator : Validator<UserCreateRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(Constants.DefaultNameLength).WithMessage("Last name must be less than 50 characters.");
        
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(Constants.DefaultNameLength).WithMessage("First name must be less than 50 characters.");
        
        RuleFor(x => x.MiddleName)
            .MaximumLength(Constants.DefaultNameLength).WithMessage("Middle name must be less than 50 characters.");
        
        RuleFor(x => x.EnglishName)
            .MaximumLength(Constants.DefaultNameLength).WithMessage("English name must be less than 50 characters.");
        
        RuleFor(x => x.SocialSecurityNumber)
            .MaximumLength(Constants.DefaultSocialSecurityNumberLength).WithMessage("Social security number must be less than 50 characters.");
        
        RuleFor(x => x.DateOfBirth)
            .GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("We do not allow mummies to use this application.")
            .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.");
        
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MaximumLength(Constants.DefaultUsernameLength).WithMessage("Username must be less than 50 characters.")
            .EmailAddress().WithMessage("Username must be a valid email address.");
        
        RuleFor(x => x.Password)
            .Custom((value, context) =>
            {
                var confirmPassword = context.InstanceToValidate.ConfirmPassword;
        
                if (string.IsNullOrWhiteSpace(value))
                {
                    context.AddFailure("Password is required.");
                }
                else if (value.Length > Constants.DefaultPasswordLength)
                {
                    context.AddFailure("Password must be less than 50 characters.");
                }
                else if (value != confirmPassword)
                {
                    context.AddFailure("Passwords do not match.");
                }
            });
    }
}
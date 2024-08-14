namespace Dotnetstore.Intranet.Organization.Users.Create;

internal sealed class CreateUserRequestValidator : Validator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(DataSchemaConstants.DefaultNameLength).WithMessage("Last name must be less than 50 characters.");
        
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(DataSchemaConstants.DefaultNameLength).WithMessage("First name must be less than 50 characters.");
        
        RuleFor(x => x.MiddleName)
            .MaximumLength(DataSchemaConstants.DefaultNameLength).WithMessage("Middle name must be less than 50 characters.");
        
        RuleFor(x => x.EnglishName)
            .MaximumLength(DataSchemaConstants.DefaultNameLength).WithMessage("English name must be less than 50 characters.");
        
        RuleFor(x => x.SocialSecurityNumber)
            .MaximumLength(DataSchemaConstants.DefaultSocialSecurityNumberLength).WithMessage("Social security number must be less than 50 characters.");
        
        RuleFor(x => x.DateOfBirth)
            .GreaterThan(DateTime.Now.AddYears(100)).WithMessage("Date of birth must be in the past.")
            .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.");
        
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MaximumLength(DataSchemaConstants.DefaultUsernameLength).WithMessage("Username must be less than 50 characters.")
            .EmailAddress().WithMessage("Username must be a valid email address.");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MaximumLength(50).WithMessage("Password must be less than 50 characters.");
        
        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Confirm password is required.")
            .MaximumLength(50).WithMessage("Confirm password must be less than 50 characters.")
            .Equal(x => x.Password).WithMessage("Passwords do not match.");
    }
}
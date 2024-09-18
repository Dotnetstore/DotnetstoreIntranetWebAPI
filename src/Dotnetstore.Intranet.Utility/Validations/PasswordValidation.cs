using System.ComponentModel.DataAnnotations;
using System.Security;
using Dotnetstore.Intranet.Utility.Services;

namespace Dotnetstore.Intranet.Utility.Validations;

public class PasswordValidation(
    string password,
    string confirmPassword) : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var propertyInfoPassword = validationContext.ObjectType.GetProperty(password);
        var propertyInfoConfirmPassword = validationContext.ObjectType.GetProperty(confirmPassword);

        if (propertyInfoPassword == null)
            return new ValidationResult($"Unknown property: {password}");
        
        if (propertyInfoConfirmPassword == null)
            return new ValidationResult($"Unknown property: {confirmPassword}");
        
        var password1 = propertyInfoPassword.GetValue(validationContext.ObjectInstance) as SecureString;
        var confirmPassword1 = propertyInfoConfirmPassword.GetValue(validationContext.ObjectInstance) as SecureString;

        if (password1 is null || confirmPassword1 is null)
            return new ValidationResult("Password or ConfirmPassword is null");
        
        var passwordAsString = password1.ToNormalString();
        var confirmPasswordAsString = confirmPassword1.ToNormalString();
        
        if (passwordAsString != confirmPasswordAsString)
            return new ValidationResult("Password and ConfirmPassword do not match");
        
        if (string.IsNullOrWhiteSpace(passwordAsString))
            return new ValidationResult("Password is empty");
        
        return ValidationResult.Success;
    }
}
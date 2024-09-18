using Dotnetstore.Intranet.Email.Contracts;
using Dotnetstore.Intranet.Utility;
using FluentValidation;

namespace Dotnetstore.Intranet.Email.SendNewRegistrationEmail;

internal sealed class SendNewRegistrationEmailCommandValidator : AbstractValidator<SendNewRegistrationEmailCommand>
{
    public SendNewRegistrationEmailCommandValidator()
    {
        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(Constants.DefaultNameLength);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(Constants.DefaultNameLength);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}
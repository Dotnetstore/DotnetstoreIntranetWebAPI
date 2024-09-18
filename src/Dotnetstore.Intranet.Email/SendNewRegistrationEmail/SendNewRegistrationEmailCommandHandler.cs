using Ardalis.Result;
using Dotnetstore.Intranet.Email.Contracts;
using MediatR;
using FluentEmail.Core;
using Microsoft.Extensions.Logging;

namespace Dotnetstore.Intranet.Email.SendNewRegistrationEmail;

internal sealed class SendNewRegistrationEmailCommandHandler(
    ILogger<SendNewRegistrationEmailCommandHandler> logger,
    IFluentEmail fluentEmail)
    : IRequestHandler<SendNewRegistrationEmailCommand, Result<bool>>
{
    async Task<Result<bool>> IRequestHandler<SendNewRegistrationEmailCommand, Result<bool>>
        .Handle(SendNewRegistrationEmailCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Attempting sending new registration email to {Email}", request.Email);

        await fluentEmail
            .To(request.Email, $"{request.FirstName} {request.LastName}")
            .Subject("Welcome to Dotnetstore Intranet!")
            .Body(request.LastNameFirst
                ? $"Welcome {request.LastName}, {request.FirstName}!"
                : $"Welcome {request.FirstName} {request.LastName}!")
            .SendAsync();
        
        return true;
    }
}
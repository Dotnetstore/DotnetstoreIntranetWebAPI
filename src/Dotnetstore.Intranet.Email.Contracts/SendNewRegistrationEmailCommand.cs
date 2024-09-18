using Ardalis.Result;
using MediatR;

namespace Dotnetstore.Intranet.Email.Contracts;

public record struct SendNewRegistrationEmailCommand(
    string LastName,
    string FirstName,
    bool LastNameFirst,
    string Email) : IRequest<Result<bool>>;
using Dotnetstore.Intranet.Utility.Loggers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using SDK.Dto.Organization.Users.Requests;
using SDK.Dto.Organization.Users.Responses;

namespace Dotnetstore.Intranet.Organization.Users.Create;

internal sealed class CreateUserEndpoint(IUserService userService) : Endpoint<UserCreateRequest, Results<Ok<UserResponse>, Conflict<ProblemDetails>, BadRequest<ProblemDetails>>>
{
    public override void Configure()
    {
        Post(ApiEndpoints.Organization.Users.Create);
        Description(b => b
                .WithDescription("Create a new user")
                .WithTags("Organization/User"));
        Summary(s =>
        {
            s.ExampleRequest = new UserCreateRequest
            {
                Username = "test@test.com",
                FirstName = "Test",
                LastName = "Testsson",
                MiddleName = "Testare",
                EnglishName = "Testing",
                SocialSecurityNumber = "123456789",
                DateOfBirth = new DateTime(1971, 5, 20),
                IsMale = true,
                LastNameFirst = true,
                Password = "Test123!",
                ConfirmPassword = "Test123!"
            };
        });
        AllowAnonymous();
        PreProcessor<RequestLogger<UserCreateRequest>>();
        PostProcessor<DurationLogger<UserCreateRequest>>();
    }

    public override async Task HandleAsync(UserCreateRequest req, CancellationToken ct)
    {
        var result = await userService.CreateAsync(req, ct);
        
        if (result.IsError)
        {
            if (result.FirstError.Type == ErrorType.Conflict)
                await SendResultAsync(TypedResults.Conflict(new ProblemDetails
                {
                    Detail = result.FirstError.Code,
                    Status = StatusCodes.Status409Conflict
                }));
            else
                await SendResultAsync(TypedResults.BadRequest(new ProblemDetails
                {
                    Detail = result.FirstError.Code,
                    Status = StatusCodes.Status400BadRequest
                }));
        }
        else
            await SendResultAsync(TypedResults.Ok(result.Value));
    }
}
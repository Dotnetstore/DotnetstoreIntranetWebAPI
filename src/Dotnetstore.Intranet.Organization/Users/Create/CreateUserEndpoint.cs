using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Dotnetstore.Intranet.Organization.Users.Create;

internal sealed class CreateUserEndpoint(IUserService userService) : Endpoint<CreateUserRequest, Results<Ok<UserResponse>, Conflict, BadRequest>>
{
    public override void Configure()
    {
        Post(ApiEndpoints.Users.Create);
        Description(b => b
                .WithDescription("Create a new user")
                .WithTags("Organization/User")
                .Accepts<CreateUserRequest>()
                .Produces<UserResponse>(200, "application/json+custom")
                .ProducesProblemDetails(400, "application/json+problem")
                .ProducesProblemFE<ProblemDetails>(409),
            clearDefaults: true);
        Summary(s =>
        {
            s.ExampleRequest = new CreateUserRequest
            {
                Username = "johndoe@test.com",
                Password = "password",
                ConfirmPassword = "password",
                FirstName = "John",
                LastName = "Doe",
                MiddleName = "M",
                EnglishName = "John",
                SocialSecurityNumber = "123456789",
                DateOfBirth = new DateTime(1980, 1, 1),
                IsMale = true,
                LastNameFirst = true
            };
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
    {
        var result = await userService.CreateAsync(req, ct);

        if (result.IsError)
        {
            if (result.FirstError.Type == ErrorType.Conflict)
                await SendResultAsync(TypedResults.Conflict(new ProblemDetails
                {
                    Detail = result.FirstError.Description,
                    Status = StatusCodes.Status409Conflict
                }));
            else
                await SendResultAsync(TypedResults.BadRequest(new ProblemDetails
                {
                    Detail = result.FirstError.Description,
                    Status = StatusCodes.Status400BadRequest
                }));
        }
        else
            await SendResultAsync(TypedResults.Ok(result.Value));
    }
}
using Ardalis.Result;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Http;
using SDK.Dto.Organization.Users.Requests;
using SDK.Dto.Organization.Users.Responses;

namespace Dotnetstore.Intranet.Organization.Users.Login;

internal sealed class LoginUserEndpoint(IUserService userService) : Endpoint<UserLoginRequest, UserLoginResponse>
{
    public override void Configure()
    {
        Post(ApiEndpoints.Organization.Users.Login);
        Description(b => b
                .WithDescription("Login user")
                .WithTags("Organization/User"));
        Summary(s =>
        {
            s.ExampleRequest = new UserLoginRequest
            {
                Username = "Username",
                Password = "Password"
            };
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(UserLoginRequest req, CancellationToken ct)
    {
        var result = await userService.LoginAsync(req, ct);

        if (result.IsError())
        {
            await SendResultAsync(TypedResults.BadRequest(new ProblemDetails
            {
                Detail = result.Errors.First(),
                Status = StatusCodes.Status400BadRequest
            }));
        }
        else
        {
            //Create jwtbearer token
            var jwtToken = JwtBearer.CreateToken(
                o =>
                {
                    o.SigningKey = "A secret token signing key. This key should be stored in a secure location. And should not be shared.";
                    o.ExpireAt = DateTime.UtcNow.AddDays(1);
                    o.User.Roles.Add("Administrator", "User");
                    o.User.Claims.Add(("UserName", req.Username));
                    o.User["UserId"] = result.Value.Id.ToString(); //indexer based claim setting
                });

            await SendAsync(new UserLoginResponse(
                result.Value,
                jwtToken), cancellation: ct);
        }
    }
}
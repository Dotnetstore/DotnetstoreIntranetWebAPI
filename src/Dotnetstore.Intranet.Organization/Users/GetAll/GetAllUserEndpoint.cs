using Dotnetstore.Intranet.Utility.Loggers;
using Microsoft.AspNetCore.Http;
using SDK.Dto.Organization.Users.Responses;

namespace Dotnetstore.Intranet.Organization.Users.GetAll;

internal sealed class GetAllUserEndpoint(IUserService userService) : EndpointWithoutRequest<IEnumerable<UserResponse>>
{
    public override void Configure()
    {
        Get(ApiEndpoints.Organization.Users.GetAll);
        Description(b => b
                .WithDescription("Get all users")
                .WithTags("Organization/User"));
        AllowAnonymous();
        PreProcessor<RequestLogger<EmptyRequest>>();
        PostProcessor<DurationLogger<EmptyRequest>>();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await userService.GetAllAsync(ct);

        await SendAsync(result, statusCode: 200, ct);
    }
}
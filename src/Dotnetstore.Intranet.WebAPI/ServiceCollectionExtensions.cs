using Dotnetstore.Intranet.Organization;
using Dotnetstore.Intranet.Utility.Extensions;
using FastEndpoints;
using FastEndpoints.Swagger;

namespace Dotnetstore.Intranet.WebAPI;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddWebApi(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddFastEndpoints()
            .SwaggerDocument(o =>
            {
                o.DocumentSettings = s =>
                {
                    s.Title = "Dotnetstore Intranet API";
                    s.Description = "API for Dotnetstore Intranet";
                    s.Version = "1.0";
                };
            })
            .AddUtility()
            .AddOrganization(configuration)
            .AddExceptionHandler<GlobalExceptionHandler>()
            .AddProblemDetails();

        return services;
    }
}
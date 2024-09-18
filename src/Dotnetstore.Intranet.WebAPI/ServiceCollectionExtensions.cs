using System.Reflection;
using Dotnetstore.Intranet.Email.Extenstions;
using Dotnetstore.Intranet.Organization;
using Dotnetstore.Intranet.Utility.Extensions;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;

namespace Dotnetstore.Intranet.WebAPI;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddWebApi(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        List<Assembly> mediatorAssemblies = [typeof(ServiceCollectionExtensions).Assembly];
        
        services
            .AddAuthenticationJwtBearer(s => s.SigningKey = "Det här är en hemlighet för att signera token. Byt ut den i produktion. Den duger i testmiljö.")
            .AddAuthorization()
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
            .AddEmail(configuration, mediatorAssemblies)
            .AddOrganization(configuration, mediatorAssemblies)
            .AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(mediatorAssemblies.ToArray()))
            .AddExceptionHandler<GlobalExceptionHandler>()
            .AddProblemDetails();

        return services;
    }
}
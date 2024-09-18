using System.Reflection;

namespace Dotnetstore.Intranet.Organization;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOrganization(
        this IServiceCollection services,
        IConfiguration configuration, 
        List<Assembly> mediatorAssemblies)
    {
        var connectionString = configuration.GetConnectionString("IntranetConnectionString");
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString, nameof(connectionString));
        
        mediatorAssemblies.Add(typeof(IOrganizationAssemblyMarker).Assembly);
        
        services
            .AddScoped<IOrganizationUnitOfWork, OrganizationUnitOfWork>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserService, UserService>()
            .AddFastEndpoints()
            .AddDbContext<OrganizationDataContext>(connectionString);
        
        using var scope = services.BuildServiceProvider().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<OrganizationDataContext>();
        
        context.Database.EnsureCreated();

        return services;
    }
}
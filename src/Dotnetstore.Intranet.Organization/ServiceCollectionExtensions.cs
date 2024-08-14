namespace Dotnetstore.Intranet.Organization;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOrganization(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("IntranetConnectionString");
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString, nameof(connectionString));
        
        services
            .AddScoped<IOrganizationUnitOfWork, OrganizationUnitOfWork>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserService, UserService>()
            .AddFastEndpoints()
            .AddDbContext<OrganizationDataContext>(connectionString);

        return services;
    }
}
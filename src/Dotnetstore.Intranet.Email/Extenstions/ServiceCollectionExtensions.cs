using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnetstore.Intranet.Email.Extenstions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEmail(
        this IServiceCollection services,
        IConfiguration configuration, 
        List<Assembly> mediatorAssemblies)
    {
        mediatorAssemblies.Add(typeof(IEmailAssemblyMarker).Assembly);
        
        var defaultSenderAddress = configuration.GetSection("Smtp:DefaultSenderAddress").Value;
        var defaultSenderName = configuration.GetSection("Smtp:DefaultSenderName").Value;
        var defaultHost = configuration.GetSection("Smtp:DefaultHost").Value;
        var success = int.TryParse(configuration.GetSection("Smtp:DefaultPort").Value, out var port);
        
        ArgumentException.ThrowIfNullOrWhiteSpace(defaultSenderAddress, nameof(defaultSenderAddress));
        ArgumentException.ThrowIfNullOrWhiteSpace(defaultSenderName, nameof(defaultSenderName));
        ArgumentException.ThrowIfNullOrWhiteSpace(defaultHost, nameof(defaultHost));
        
        if(!success)
            ArgumentException.ThrowIfNullOrWhiteSpace(port.ToString(), nameof(port));
        
        services
            .AddFluentEmail(defaultSenderAddress, defaultSenderName)
            .AddSmtpSender(defaultHost, port);
        
        return services;
    }
}
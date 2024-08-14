using Dotnetstore.Intranet.Utility.Extensions;
using FastEndpoints.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.MsSql;

namespace Dotnetstore.Intranet.Organization.Test.Integration;

public class DotnetstoreIntranetBase : AppFixture<Program>
{
    private IServiceCollection _services = null!;
    private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder().Build();

    protected override Task PreSetupAsync()
    {
        return Task.CompletedTask;
    }

    protected override Task SetupAsync()
    {
        return Task.CompletedTask;
    }

    protected override void ConfigureApp(IWebHostBuilder a)
    {
        _msSqlContainer.StartAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        
        a.ConfigureTestServices(x =>
        {
            _services = x;
            _services.RemoveDbContext<OrganizationDataContext>();
            _services.AddDbContext<OrganizationDataContext>(_msSqlContainer.GetConnectionString());
            _services.EnsureDbCreated<OrganizationDataContext>();
        });
    }

    protected override void ConfigureServices(IServiceCollection s)
    {
    }

    protected override Task TearDownAsync()
    {
        _msSqlContainer.StopAsync();
        return Task.CompletedTask;
    }
}
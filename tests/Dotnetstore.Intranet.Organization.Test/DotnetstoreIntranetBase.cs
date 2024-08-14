using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;
using Xunit;

namespace Dotnetstore.Intranet.Organization.Test;

public abstract class DotnetstoreIntranetBase : IAsyncLifetime
{
    private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder().Build();
    internal readonly OrganizationDataContext DataContext;
    internal readonly IOrganizationUnitOfWork UnitOfWork;
    internal readonly CancellationToken CancellationToken = new CancellationTokenSource().Token;

    protected DotnetstoreIntranetBase()
    {
        _msSqlContainer.StartAsync(CancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
        var options = new DbContextOptionsBuilder<OrganizationDataContext>()
            .UseSqlServer(_msSqlContainer.GetConnectionString())
            .Options;
        DataContext = new OrganizationDataContext(options);
        DataContext.Database.EnsureCreated();
        UnitOfWork = new OrganizationUnitOfWork(DataContext);
    }

    public async Task InitializeAsync()
    {
        // await _msSqlContainer.StartAsync(CancellationToken);
        await Task.CompletedTask;
    }

    public async Task DisposeAsync()
    {
        await _msSqlContainer.StopAsync(CancellationToken);
    }
}
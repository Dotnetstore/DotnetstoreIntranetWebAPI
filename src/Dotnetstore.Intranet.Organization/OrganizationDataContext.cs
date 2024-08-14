namespace Dotnetstore.Intranet.Organization;

internal sealed class OrganizationDataContext(DbContextOptions<OrganizationDataContext> options) : ApiContext<OrganizationDataContext>(options)
{
    internal DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.HasDefaultSchema("Organization");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IOrganizationAssemblyMarker).Assembly);
    }
}
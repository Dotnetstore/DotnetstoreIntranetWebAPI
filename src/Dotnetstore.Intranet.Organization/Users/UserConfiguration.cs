namespace Dotnetstore.Intranet.Organization.Users;

internal sealed class UserConfiguration : IdentityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        
        var converter = new ValueConverter<UserId, Guid>(
            id => id.Id, 
            guid => new UserId(guid));
        
        builder
            .HasKey(q => q.UserId);
        
        builder
            .Property(q => q.UserId)
            .HasConversion(converter)
            .ValueGeneratedNever()
            .IsRequired();
    }
}
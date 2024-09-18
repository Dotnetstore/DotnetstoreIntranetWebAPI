using Dotnetstore.Intranet.Organization.UserRoles;

namespace Dotnetstore.Intranet.Organization.UserInUserRoles;

internal sealed class UserInUserRoleConfiguration : BaseAuditableEntityConfiguration<UserInUserRole>
{
    public override void Configure(EntityTypeBuilder<UserInUserRole> builder)
    {
        base.Configure(builder);
        
        var converterUserInUserRoleId = new ValueConverter<UserInUserRoleId, Guid>(
            id => id.Value, 
            guid => new UserInUserRoleId(guid));
        
        var converterUserId = new ValueConverter<UserId, Guid>(
            id => id.Value,
            guid => new UserId(guid));

        var converterUserRoleId = new ValueConverter<UserRoleId, Guid>(
            id => id.Id,
            guid => new UserRoleId(guid));
        
        builder
            .HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Id)
            .IsUnique();

        builder
            .HasIndex(x => new { x.UserRoleId, x.UserId });

        builder
            .Property(x => x.Id)
            .HasConversion(converterUserInUserRoleId)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .Property(x => x.UserId)
            .HasConversion(converterUserId)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .Property(x => x.UserRoleId)
            .HasConversion(converterUserRoleId)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.UserInUserRoles)
            .HasForeignKey(x => x.UserId)
            .IsRequired();

        builder
            .HasOne(x => x.UserRole)
            .WithMany(x => x.UserInUserRoles)
            .HasForeignKey(x => x.UserRoleId)
            .IsRequired();

        builder
            .HasData(
                new UserInUserRole
                {
                    Id = new UserInUserRoleId(Guid.NewGuid()),
                    UserId = new UserId(Constants.SystemUserId),
                    UserRoleId = new UserRoleId(Constants.UserRoleAdministratorId),
                    CreatedDate = DateTimeOffset.Now,
                    IsSystem = true
                },
                new UserInUserRole
                {
                    Id = new UserInUserRoleId(Guid.NewGuid()),
                    UserId = new UserId(Constants.SystemUserId),
                    UserRoleId = new UserRoleId(Constants.UserRoleUserId),
                    CreatedDate = DateTimeOffset.Now,
                    IsSystem = true
                });
    }
}
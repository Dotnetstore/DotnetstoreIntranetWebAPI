namespace Dotnetstore.Intranet.Organization.UserGroups;

internal sealed class UserGroupConfiguration : BaseAuditableEntityConfiguration<UserGroup>
{
    public override void Configure(EntityTypeBuilder<UserGroup> builder)
    {
        base.Configure(builder);
        
        var converter = new ValueConverter<UserGroupId, Guid>(
            id => id.Id, 
            guid => new UserGroupId(guid));
        
        builder
            .HasKey(x => x.UserGroupId);

        builder
            .HasIndex(x => x.UserGroupId)
            .IsUnique()
            .HasDatabaseName("Index_Id");
        
        builder
            .HasIndex(x => x.IsDeleted)
            .HasDatabaseName("Index_IsDeleted");

        builder
            .Property(x => x.UserGroupId)
            .HasConversion(converter)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .Property(x => x.Name)
            .HasMaxLength(Constants.DefaultNameLength)
            .IsRequired()
            .IsUnicode();

        builder
            .HasData(
                new UserGroup
                {
                    CreatedDate = DateTimeOffset.Now,
                    IsDeleted = false,
                    IsGdpr = false,
                    IsSystem = true,
                    Name = "Administrators",
                    UserGroupId = new UserGroupId(Constants.UserGroupAdministratorsId)
                },
                new UserGroup
                {
                    CreatedDate = DateTimeOffset.Now,
                    IsDeleted = false,
                    IsGdpr = false,
                    IsSystem = true,
                    Name = "Super users",
                    UserGroupId = new UserGroupId(Constants.UserGroupSuperUsersId)
                },
                new UserGroup
                {
                    CreatedDate = DateTimeOffset.Now,
                    IsDeleted = false,
                    IsGdpr = false,
                    IsSystem = true,
                    Name = "Users",
                    UserGroupId = new UserGroupId(Constants.UserGroupUsersId)
                });
    }
}
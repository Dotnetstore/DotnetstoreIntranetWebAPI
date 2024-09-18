using Dotnetstore.Intranet.Organization.UserGroups;

namespace Dotnetstore.Intranet.Organization.UserInUserGroups;

internal sealed class UserInUserGroupConfiguration : BaseAuditableEntityConfiguration<UserInUserGroup>
{
    public override void Configure(EntityTypeBuilder<UserInUserGroup> builder)
    {
        base.Configure(builder);
        
        var converterUserInUserGroupId = new ValueConverter<UserInUserGroupId, Guid>(
            id => id.Value, 
            guid => new UserInUserGroupId(guid));
        
        var converterUserId = new ValueConverter<UserId, Guid>(
            id => id.Value, 
            guid => new UserId(guid));
        
        var converterUserGroupId = new ValueConverter<UserGroupId, Guid>(
            id => id.Id, 
            guid => new UserGroupId(guid));
        
        builder
            .HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Id)
            .IsUnique();

        builder
            .HasIndex(x => new { x.UserGroupId, x.UserId });

        builder
            .Property(x => x.Id)
            .HasConversion(converterUserInUserGroupId)
            .ValueGeneratedNever()
            .IsRequired();
        
        builder
            .Property(x => x.UserId)
            .HasConversion(converterUserId)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .Property(x => x.UserGroupId)
            .HasConversion(converterUserGroupId)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.UserInUserGroups)
            .HasForeignKey(x => x.UserId)
            .IsRequired();

        builder
            .HasOne(x => x.UserGroup)
            .WithMany(x => x.UserInUserGroups)
            .HasForeignKey(x => x.UserGroupId)
            .IsRequired();

        builder
            .HasData(
                new UserInUserGroup
                {
                    Id = new UserInUserGroupId(Guid.NewGuid()),
                    UserId = new UserId(Constants.SystemUserId),
                    UserGroupId = new UserGroupId(Constants.UserGroupAdministratorsId),
                    CreatedDate = DateTimeOffset.Now,
                    IsSystem = true
                },
                new UserInUserGroup
                {
                    Id = new UserInUserGroupId(Guid.NewGuid()),
                    UserId = new UserId(Constants.SystemUserId),
                    UserGroupId = new UserGroupId(Constants.UserGroupUsersId),
                    CreatedDate = DateTimeOffset.Now,
                    IsSystem = true
                });
    }
}
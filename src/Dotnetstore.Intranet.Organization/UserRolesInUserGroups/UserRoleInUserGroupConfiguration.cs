using Dotnetstore.Intranet.Organization.UserGroups;
using Dotnetstore.Intranet.Organization.UserRoles;

namespace Dotnetstore.Intranet.Organization.UserRolesInUserGroups;

internal sealed class UserRoleInUserGroupConfiguration : BaseAuditableEntityConfiguration<UserRoleInUserGroup>
{
    public override void Configure(EntityTypeBuilder<UserRoleInUserGroup> builder)
    {
        base.Configure(builder);
        
        var converterUserRoleInUserGroupId = new ValueConverter<UserRoleInUserGroupId, Guid>(
            id => id.Id, 
            guid => new UserRoleInUserGroupId(guid));
        
        var converterUserGroupId = new ValueConverter<UserGroupId, Guid>(
            id => id.Id, 
            guid => new UserGroupId(guid));
        
        var converterUserRoleId = new ValueConverter<UserRoleId, Guid>(
            id => id.Id, 
            guid => new UserRoleId(guid));
        
        builder
            .HasKey(x => x.UserRoleInUserGroupId);

        builder
            .HasIndex(x => x.UserRoleInUserGroupId)
            .IsUnique()
            .HasDatabaseName("Index_Id");
        
        builder
            .HasIndex(x => x.IsDeleted)
            .HasDatabaseName("Index_IsDeleted");

        builder
            .HasIndex(x => new { x.UserRoleId, x.UserGroupId });

        builder
            .Property(x => x.UserRoleInUserGroupId)
            .HasConversion(converterUserRoleInUserGroupId)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .Property(x => x.UserGroupId)
            .HasConversion(converterUserGroupId)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .Property(x => x.UserRoleId)
            .HasConversion(converterUserRoleId)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .HasOne(x => x.UserGroup)
            .WithMany(x => x.UserRoleInUserGroups)
            .HasForeignKey(x => x.UserGroupId)
            .IsRequired();

        builder
            .HasOne(x => x.UserRole)
            .WithMany(x => x.UserRoleInUserGroups)
            .HasForeignKey(x => x.UserRoleId)
            .IsRequired();

        builder
            .HasData(
                new UserRoleInUserGroup
                {
                    CreatedDate = DateTimeOffset.Now,
                    IsDeleted = false,
                    IsGdpr = false,
                    IsSystem = true,
                    UserRoleInUserGroupId = new UserRoleInUserGroupId(Guid.NewGuid()),
                    UserGroupId = new UserGroupId(Constants.UserGroupAdministratorsId),
                    UserRoleId = new UserRoleId(Constants.UserRoleAdministratorId)
                },
                new UserRoleInUserGroup
                {
                    CreatedDate = DateTimeOffset.Now,
                    IsDeleted = false,
                    IsGdpr = false,
                    IsSystem = true,
                    UserRoleInUserGroupId = new UserRoleInUserGroupId(Guid.NewGuid()),
                    UserGroupId = new UserGroupId(Constants.UserGroupSuperUsersId),
                    UserRoleId = new UserRoleId(Constants.UserRoleSuperUserId)
                },
                new UserRoleInUserGroup
                {
                    CreatedDate = DateTimeOffset.Now,
                    IsDeleted = false,
                    IsGdpr = false,
                    IsSystem = true,
                    UserRoleInUserGroupId = new UserRoleInUserGroupId(Guid.NewGuid()),
                    UserGroupId = new UserGroupId(Constants.UserGroupUsersId),
                    UserRoleId = new UserRoleId(Constants.UserRoleUserId)
                });
    }
}
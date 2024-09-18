using Dotnetstore.Intranet.Organization.UserGroups;
using Dotnetstore.Intranet.Organization.UserRoles;
using Dotnetstore.Intranet.Organization.UserRolesInUserGroups;
using Dotnetstore.Intranet.Utility;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Xunit;

namespace Dotnetstore.Intranet.Organization.Test.UserRoles;

public class UserRoleConfigurationTests
{
    private class TestDbContext : DbContext
    {
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserRoleConfiguration().Configure(modelBuilder.Entity<UserRole>());
            new UserGroupConfiguration().Configure(modelBuilder.Entity<UserGroup>());
            new UserRoleInUserGroupConfiguration().Configure(modelBuilder.Entity<UserRoleInUserGroup>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDb");
        }
    }

    [Fact]
    public void UserRoleConfiguration_Should_Set_Keys_And_Indexes()
    {
        // Arrange
        using var context = new TestDbContext();
        var entityType = context.Model.FindEntityType(typeof(UserRole));

        // Act
        var key = entityType!.FindPrimaryKey();
        var userRoleIdIndex = entityType.GetIndexes().FirstOrDefault(i => i.Properties.Any(p => p.Name == nameof(UserRole.UserRoleId)));
        var isDeletedIndex = entityType.GetIndexes().FirstOrDefault(i => i.Properties.Any(p => p.Name == nameof(UserRole.IsDeleted)));

        // Assert
        key!.Properties.Should().ContainSingle(p => p.Name == nameof(UserRole.UserRoleId));
        userRoleIdIndex.Should().NotBeNull();
        userRoleIdIndex!.IsUnique.Should().BeTrue();
        isDeletedIndex.Should().NotBeNull();
    }

    [Fact]
    public void UserRoleConfiguration_Should_Set_Properties()
    {
        // Arrange
        using var context = new TestDbContext();
        var entityType = context.Model.FindEntityType(typeof(UserRole));

        // Act
        var userRoleIdProperty = entityType!.FindProperty(nameof(UserRole.UserRoleId));
        var nameProperty = entityType.FindProperty(nameof(UserRole.Name));

        // Assert
        userRoleIdProperty!.IsNullable.Should().BeFalse();
        userRoleIdProperty.ValueGenerated.Should().Be(ValueGenerated.Never);
        nameProperty!.IsNullable.Should().BeFalse();
        nameProperty.GetMaxLength().Should().Be(Constants.DefaultNameLength);
        nameProperty.IsUnicode().Should().BeTrue();
    }
}
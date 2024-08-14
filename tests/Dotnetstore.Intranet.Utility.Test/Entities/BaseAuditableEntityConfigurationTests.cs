using Dotnetstore.Intranet.Utility.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Dotnetstore.Intranet.Utility.Test.Entities;

public class BaseAuditableEntityConfigurationTests
{
    [Fact]
    public void Test_Configuration()
    {
        var builder = new ModelBuilder(new Microsoft.EntityFrameworkCore.Metadata.Conventions.ConventionSet());
        var entityBuilder = builder.Entity<TestAuditableEntityTest>();

        var configuration = new TestAuditableEntityConfiguration();
        configuration.Configure(entityBuilder);

        var createdByProperty = entityBuilder.Metadata.FindProperty(nameof(TestAuditableEntityTest.CreatedBy));
        createdByProperty?.IsNullable.Should().BeTrue();

        var createdDateProperty = entityBuilder.Metadata.FindProperty(nameof(TestAuditableEntityTest.CreatedDate));
        createdDateProperty?.IsNullable.Should().BeFalse();

        var lastUpdatedByProperty = entityBuilder.Metadata.FindProperty(nameof(TestAuditableEntityTest.LastUpdatedBy));
        lastUpdatedByProperty?.IsNullable.Should().BeTrue();

        var lastUpdatedDateProperty = entityBuilder.Metadata.FindProperty(nameof(TestAuditableEntityTest.LastUpdatedDate));
        lastUpdatedDateProperty?.IsNullable.Should().BeTrue();

        var isDeletedProperty = entityBuilder.Metadata.FindProperty(nameof(TestAuditableEntityTest.IsDeleted));
        isDeletedProperty?.IsNullable.Should().BeFalse();

        var deletedByProperty = entityBuilder.Metadata.FindProperty(nameof(TestAuditableEntityTest.DeletedBy));
        deletedByProperty?.IsNullable.Should().BeTrue();

        var deletedDateProperty = entityBuilder.Metadata.FindProperty(nameof(TestAuditableEntityTest.DeletedDate));
        deletedDateProperty?.IsNullable.Should().BeTrue();

        var isSystemProperty = entityBuilder.Metadata.FindProperty(nameof(TestAuditableEntityTest.IsSystem));
        isSystemProperty?.IsNullable.Should().BeFalse();

        var isGdprProperty = entityBuilder.Metadata.FindProperty(nameof(TestAuditableEntityTest.IsGdpr));
        isGdprProperty?.IsNullable.Should().BeFalse();
    }
}

public class TestAuditableEntityTest : BaseAuditableEntity
{
    // No additional implementation needed for testing
}

public class TestAuditableEntityConfiguration : BaseAuditableEntityConfiguration<TestAuditableEntityTest>
{
    // No additional implementation needed for testing
}
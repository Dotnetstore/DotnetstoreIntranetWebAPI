using Dotnetstore.Intranet.Utility.Entities;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.Utility.Test.Entities;

public class BaseAuditableEntityTests
{
    [Fact]
    public void Test_CreatedBy_Property()
    {
        var entity = new TestAuditableEntity();
        var userId = Guid.NewGuid();
        entity.CreatedBy = userId;
        entity.CreatedBy.Should().Be(userId);
    }

    [Fact]
    public void Test_CreatedDate_Property()
    {
        var entity = new TestAuditableEntity();
        var createdDate = DateTimeOffset.UtcNow;
        entity.CreatedDate = createdDate;
        entity.CreatedDate.Should().Be(createdDate);
    }

    [Fact]
    public void Test_LastUpdatedBy_Property()
    {
        var entity = new TestAuditableEntity();
        var userId = Guid.NewGuid();
        entity.LastUpdatedBy = userId;
        entity.LastUpdatedBy.Should().Be(userId);
    }

    [Fact]
    public void Test_LastUpdatedDate_Property()
    {
        var entity = new TestAuditableEntity();
        var updatedDate = DateTimeOffset.UtcNow;
        entity.LastUpdatedDate = updatedDate;
        entity.LastUpdatedDate.Should().Be(updatedDate);
    }

    [Fact]
    public void Test_IsDeleted_Property()
    {
        var entity = new TestAuditableEntity
        {
            IsDeleted = true
        };
        entity.IsDeleted.Should().BeTrue();
    }

    [Fact]
    public void Test_DeletedBy_Property()
    {
        var entity = new TestAuditableEntity();
        var userId = Guid.NewGuid();
        entity.DeletedBy = userId;
        entity.DeletedBy.Should().Be(userId);
    }

    [Fact]
    public void Test_DeletedDate_Property()
    {
        var entity = new TestAuditableEntity();
        var deletedDate = DateTimeOffset.UtcNow;
        entity.DeletedDate = deletedDate;
        entity.DeletedDate.Should().Be(deletedDate);
    }

    [Fact]
    public void Test_IsSystem_Property()
    {
        var entity = new TestAuditableEntity
        {
            IsSystem = true
        };
        entity.IsSystem.Should().BeTrue();
    }

    [Fact]
    public void Test_IsGdpr_Property()
    {
        var entity = new TestAuditableEntity
        {
            IsGdpr = true
        };
        entity.IsGdpr.Should().BeTrue();
    }
}

public class TestAuditableEntity : BaseAuditableEntity
{
    // No additional implementation needed for testing
}

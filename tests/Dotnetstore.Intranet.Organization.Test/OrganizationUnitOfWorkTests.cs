using Dotnetstore.Intranet.Organization.Test.TestData;
using Dotnetstore.Intranet.Organization.Users;
using FastEndpoints.Testing;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Dotnetstore.Intranet.Organization.Test;

public class OrganizationUnitOfWorkTests : DotnetstoreIntranetBase
{
    [Fact, Priority(1)]
    public void Repository_Should_Return_Repository_Instance()
    {
        // Act
        var repository = UnitOfWork.Repository<User>();

        // Assert
        repository.Should().NotBeNull();
    }

    [Fact, Priority(2)]
    public async Task SaveChangesAsync_Should_Save_Changes()
    {
        // Arrange
        var user = UserTestData.CreateTestUser();
        UnitOfWork.Repository<User>().Create(user);

        // Act
        await UnitOfWork.SaveChangesAsync(CancellationToken);

        // Assert
        user.UserId.Value.Should().NotBeEmpty();
    }

    [Fact, Priority(3)]
    public void Rollback_Should_Rollback_Changes()
    {
        // Arrange
        var user = UserTestData.CreateTestUser(username: "testar@testar.com", lastName: "Sjödin");
        UnitOfWork.Repository<User>().Create(user);

        // Act
        UnitOfWork.Rollback();

        // Assert
        DataContext.Entry(user).State.Should().Be(EntityState.Added);
        
        UnitOfWork.Dispose();
    }
}
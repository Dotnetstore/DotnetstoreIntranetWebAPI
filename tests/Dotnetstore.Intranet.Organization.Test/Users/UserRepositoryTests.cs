using Dotnetstore.Intranet.Organization.Test.TestData;
using Dotnetstore.Intranet.Organization.Users;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.Organization.Test.Users;

public class UserRepositoryTests : DotnetstoreIntranetBase
{
    private readonly IUserRepository _userRepository;

    public UserRepositoryTests()
    {
        _userRepository = new UserRepository(UnitOfWork);
    }
    
    [Fact]
    public async Task GetByUsernameAsync_WhenUserExists_ReturnsUser()
    {
        // Arrange
        var user = UserTestData.CreateTestUser();
        UnitOfWork.Repository<User>().Create(user);
        await UnitOfWork.SaveChangesAsync(CancellationToken);
        
        // Act
        var result = await _userRepository.GetByUsernameAsync("test@test.com", CancellationToken.None);
        
        // Assert
        result.Should().NotBeNull();
        result!.Username.Should().Be("test@test.com");
    }
    
    [Fact]
    public async Task GetByUsernameAsync_WhenUserDontExists_ReturnsNull()
    {
        // Arrange
        var user = UserTestData.CreateTestUser();
        UnitOfWork.Repository<User>().Create(user);
        await UnitOfWork.SaveChangesAsync(CancellationToken);
        
        // Act
        var result = await _userRepository.GetByUsernameAsync("test1@test.com", CancellationToken.None);
        
        // Assert
        result.Should().BeNull();
    }
}
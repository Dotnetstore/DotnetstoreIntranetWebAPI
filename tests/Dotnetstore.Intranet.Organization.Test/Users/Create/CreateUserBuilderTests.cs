using Dotnetstore.Intranet.Organization.Users.Create;
using FluentAssertions;
using FluentAssertions.Execution;
using SDK.Dto.Users.Requests;
using Xunit;

namespace Dotnetstore.Intranet.Organization.Test.Users.Create;

public class CreateUserBuilderTests
{
    [Fact]
    public void CreateUserBuilder_ReturnsValidUser()
    {
        var request = new CreateUserRequest(
            "Doe", 
            "John", 
            "A.", 
            "Johnny", 
            "123-45-6789", 
            new DateTime(1990, 1, 1), 
            true, 
            true, 
            "test@test.com", 
            "password", 
            "password");
        
        var user = CreateUserBuilder
            .CreateNewUser()
            .CreateUserId()
            .SetPersonalData(request)
            .SetCredentials(request)
            .SetMetaData()
            .Build();

        using (new AssertionScope())
        {
            user.Should().NotBeNull();
            user.LastName.Should().Be("Doe");
            user.FirstName.Should().Be("John");
            user.MiddleName.Should().Be("A.");
            user.EnglishName.Should().Be("Johnny");
            user.SocialSecurityNumber.Should().Be("123-45-6789");
            user.DateOfBirth.Should().Be(new DateTime(1990, 1, 1));
            user.IsMale.Should().BeTrue();
            user.LastNameFirst.Should().BeTrue();
            user.Username.Should().Be("test@test.com");
            user.Password.Should().NotBeEmpty();
            user.Salt1.Should().HaveLength(300);
            user.Salt2.Should().HaveLength(300);
            user.Salt3.Should().HaveLength(300);
            user.Salt4.Should().HaveLength(300);
        }
    }
}
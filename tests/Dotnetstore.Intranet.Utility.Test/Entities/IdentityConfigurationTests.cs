using Dotnetstore.Intranet.Utility.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Dotnetstore.Intranet.Utility.Test.Entities;

public class IdentityConfigurationTests
{
    [Fact]
    public void Test_Configuration()
    {
        var builder = new ModelBuilder(new Microsoft.EntityFrameworkCore.Metadata.Conventions.ConventionSet());
        var entityBuilder = builder.Entity<TestIdentityTest>();

        var configuration = new TestIdentityConfiguration();
        configuration.Configure(entityBuilder);

        var usernameProperty = entityBuilder.Metadata.FindProperty(nameof(TestIdentityTest.Username));
        usernameProperty!.IsNullable.Should().BeFalse();
        usernameProperty.IsUnicode().Should().BeFalse();
        usernameProperty.GetMaxLength().Should().Be(Constants.DefaultUsernameLength);

        var passwordProperty = entityBuilder.Metadata.FindProperty(nameof(TestIdentityTest.Password));
        passwordProperty!.IsNullable.Should().BeFalse();
        passwordProperty.IsUnicode().Should().BeFalse();
        passwordProperty.GetMaxLength().Should().Be(Constants.DefaultPasswordLength);

        var salt1Property = entityBuilder.Metadata.FindProperty(nameof(TestIdentityTest.Salt1));
        salt1Property!.IsNullable.Should().BeFalse();
        salt1Property.IsUnicode().Should().BeFalse();
        salt1Property.GetMaxLength().Should().Be(Constants.DefaultSaltLength);

        var salt2Property = entityBuilder.Metadata.FindProperty(nameof(TestIdentityTest.Salt2));
        salt2Property!.IsNullable.Should().BeFalse();
        salt2Property.IsUnicode().Should().BeFalse();
        salt2Property.GetMaxLength().Should().Be(Constants.DefaultSaltLength);

        var salt3Property = entityBuilder.Metadata.FindProperty(nameof(TestIdentityTest.Salt3));
        salt3Property!.IsNullable.Should().BeFalse();
        salt3Property.IsUnicode().Should().BeFalse();
        salt3Property.GetMaxLength().Should().Be(Constants.DefaultSaltLength);

        var salt4Property = entityBuilder.Metadata.FindProperty(nameof(TestIdentityTest.Salt4));
        salt4Property!.IsNullable.Should().BeFalse();
        salt4Property.IsUnicode().Should().BeFalse();
        salt4Property.GetMaxLength().Should().Be(Constants.DefaultSaltLength);

        var isBlockedProperty = entityBuilder.Metadata.FindProperty(nameof(TestIdentityTest.IsBlocked));
        isBlockedProperty!.IsNullable.Should().BeFalse();

        var blockedDateProperty = entityBuilder.Metadata.FindProperty(nameof(TestIdentityTest.BlockedDate));
        blockedDateProperty!.IsNullable.Should().BeTrue();
    }
}

public class TestIdentityTest : Identity
{
    // No additional implementation needed for testing
}

public class TestIdentityConfiguration : IdentityConfiguration<TestIdentityTest>
{
    // No additional implementation needed for testing
}
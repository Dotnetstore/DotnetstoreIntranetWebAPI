using Dotnetstore.Intranet.Organization.Users;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Xunit;

namespace Dotnetstore.Intranet.Organization.Test.Users;

public class UserConfigurationTests
{
    [Fact]
    public void Test_Configuration()
    {
        var builder = new ModelBuilder(new Microsoft.EntityFrameworkCore.Metadata.Conventions.ConventionSet());
        var entityBuilder = builder.Entity<User>();

        var configuration = new UserConfiguration();
        configuration.Configure(entityBuilder);

        var userIdProperty = entityBuilder.Metadata.FindProperty(nameof(User.UserId));
        userIdProperty!.IsNullable.Should().BeFalse();
        userIdProperty.ValueGenerated.Should().Be(ValueGenerated.Never);

        var converter = userIdProperty.GetValueConverter();
        converter.Should().NotBeNull();
        converter.Should().BeOfType<ValueConverter<UserId, Guid>>();
    }
}
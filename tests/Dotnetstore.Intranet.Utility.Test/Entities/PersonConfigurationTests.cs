using Dotnetstore.Intranet.Utility.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Dotnetstore.Intranet.Utility.Test.Entities;

public class PersonConfigurationTests
{
    [Fact]
    public void Test_Configuration()
    {
        var builder = new ModelBuilder(new Microsoft.EntityFrameworkCore.Metadata.Conventions.ConventionSet());
        var entityBuilder = builder.Entity<TestPersonTest>();

        var configuration = new TestPersonConfiguration();
        configuration.Configure(entityBuilder);

        var lastNameProperty = entityBuilder.Metadata.FindProperty(nameof(TestPersonTest.LastName));
        lastNameProperty!.IsNullable.Should().BeFalse();
        lastNameProperty.IsUnicode().Should().BeTrue();
        lastNameProperty.GetMaxLength().Should().Be(Constants.DefaultNameLength);

        var firstNameProperty = entityBuilder.Metadata.FindProperty(nameof(TestPersonTest.FirstName));
        firstNameProperty!.IsNullable.Should().BeFalse();
        firstNameProperty.IsUnicode().Should().BeTrue();
        firstNameProperty.GetMaxLength().Should().Be(Constants.DefaultNameLength);

        var middleNameProperty = entityBuilder.Metadata.FindProperty(nameof(TestPersonTest.MiddleName));
        middleNameProperty!.IsNullable.Should().BeTrue();
        middleNameProperty.IsUnicode().Should().BeTrue();
        middleNameProperty.GetMaxLength().Should().Be(Constants.DefaultNameLength);

        var englishNameProperty = entityBuilder.Metadata.FindProperty(nameof(TestPersonTest.EnglishName));
        englishNameProperty!.IsNullable.Should().BeTrue();
        englishNameProperty.IsUnicode().Should().BeTrue();
        englishNameProperty.GetMaxLength().Should().Be(Constants.DefaultNameLength);

        var ssnProperty = entityBuilder.Metadata.FindProperty(nameof(TestPersonTest.SocialSecurityNumber));
        ssnProperty!.IsNullable.Should().BeTrue();
        ssnProperty.IsUnicode().Should().BeFalse();
        ssnProperty.GetMaxLength().Should().Be(Constants.DefaultSocialSecurityNumberLength);

        var dobProperty = entityBuilder.Metadata.FindProperty(nameof(TestPersonTest.DateOfBirth));
        dobProperty!.IsNullable.Should().BeTrue();

        var isMaleProperty = entityBuilder.Metadata.FindProperty(nameof(TestPersonTest.IsMale));
        isMaleProperty!.IsNullable.Should().BeFalse();

        var lastNameFirstProperty = entityBuilder.Metadata.FindProperty(nameof(TestPersonTest.LastNameFirst));
        lastNameFirstProperty!.IsNullable.Should().BeFalse();
    }
}

public class TestPersonTest : Person
{
    // No additional implementation needed for testing
}

public class TestPersonConfiguration : PersonConfiguration<TestPersonTest>
{
    // No additional implementation needed for testing
}
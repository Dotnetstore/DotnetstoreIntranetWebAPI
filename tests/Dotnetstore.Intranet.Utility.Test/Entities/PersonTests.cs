using Dotnetstore.Intranet.Utility.Entities;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.Utility.Test.Entities;

public class PersonTests
{
    [Fact]
    public void Test_LastName_Property()
    {
        var person = new TestPerson();
        var lastName = "Doe";
        person.LastName = lastName;
        person.LastName.Should().Be(lastName);
    }

    [Fact]
    public void Test_FirstName_Property()
    {
        var person = new TestPerson();
        var firstName = "John";
        person.FirstName = firstName;
        person.FirstName.Should().Be(firstName);
    }

    [Fact]
    public void Test_MiddleName_Property()
    {
        var person = new TestPerson();
        var middleName = "A.";
        person.MiddleName = middleName;
        person.MiddleName.Should().Be(middleName);
    }

    [Fact]
    public void Test_EnglishName_Property()
    {
        var person = new TestPerson();
        var englishName = "Johnny";
        person.EnglishName = englishName;
        person.EnglishName.Should().Be(englishName);
    }

    [Fact]
    public void Test_SocialSecurityNumber_Property()
    {
        var person = new TestPerson();
        var ssn = "123-45-6789";
        person.SocialSecurityNumber = ssn;
        person.SocialSecurityNumber.Should().Be(ssn);
    }

    [Fact]
    public void Test_DateOfBirth_Property()
    {
        var person = new TestPerson();
        var dob = new DateTime(1990, 1, 1);
        person.DateOfBirth = dob;
        person.DateOfBirth.Should().Be(dob);
    }

    [Fact]
    public void Test_IsMale_Property()
    {
        var person = new TestPerson
        {
            IsMale = true
        };
        person.IsMale.Should().BeTrue();
    }

    [Fact]
    public void Test_LastNameFirst_Property()
    {
        var person = new TestPerson
        {
            LastNameFirst = true
        };
        person.LastNameFirst.Should().BeTrue();
    }

    [Fact]
    public void Test_ToString_LastNameFirst()
    {
        var person = new TestPerson
        {
            LastName = "Doe",
            FirstName = "John",
            MiddleName = "A.",
            EnglishName = "Johnny",
            LastNameFirst = true
        };
        var expected = "Doe, John A. (Johnny)";
        person.ToString().Should().Be(expected);
    }

    [Fact]
    public void Test_ToString_FirstNameFirst()
    {
        var person = new TestPerson
        {
            LastName = "Doe",
            FirstName = "John",
            MiddleName = "A.",
            EnglishName = "Johnny",
            LastNameFirst = false
        };
        var expected = "John A. Doe (Johnny)";
        person.ToString().Should().Be(expected);
    }
}

public class TestPerson : Person
{
    // No additional implementation needed for testing
}
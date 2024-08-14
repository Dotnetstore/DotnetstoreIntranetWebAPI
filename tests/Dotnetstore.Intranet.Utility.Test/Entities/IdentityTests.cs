using Dotnetstore.Intranet.Utility.Entities;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.Utility.Test.Entities;

public class IdentityTests
{
    [Fact]
    public void Test_Username_Property()
    {
        var identity = new TestIdentity();
        var username = "testuser";
        identity.Username = username;
        identity.Username.Should().Be(username);
    }

    [Fact]
    public void Test_Password_Property()
    {
        var identity = new TestIdentity();
        var password = "password123";
        identity.Password = password;
        identity.Password.Should().Be(password);
    }

    [Fact]
    public void Test_Salt1_Property()
    {
        var identity = new TestIdentity();
        var salt1 = "salt1";
        identity.Salt1 = salt1;
        identity.Salt1.Should().Be(salt1);
    }

    [Fact]
    public void Test_Salt2_Property()
    {
        var identity = new TestIdentity();
        var salt2 = "salt2";
        identity.Salt2 = salt2;
        identity.Salt2.Should().Be(salt2);
    }

    [Fact]
    public void Test_Salt3_Property()
    {
        var identity = new TestIdentity();
        var salt3 = "salt3";
        identity.Salt3 = salt3;
        identity.Salt3.Should().Be(salt3);
    }

    [Fact]
    public void Test_Salt4_Property()
    {
        var identity = new TestIdentity();
        var salt4 = "salt4";
        identity.Salt4 = salt4;
        identity.Salt4.Should().Be(salt4);
    }

    [Fact]
    public void Test_IsBlocked_Property()
    {
        var identity = new TestIdentity();
        identity.IsBlocked = true;
        identity.IsBlocked.Should().BeTrue();
    }

    [Fact]
    public void Test_BlockedDate_Property()
    {
        var identity = new TestIdentity();
        var blockedDate = DateTimeOffset.UtcNow;
        identity.BlockedDate = blockedDate;
        identity.BlockedDate.Should().Be(blockedDate);
    }
}

public class TestIdentity : Identity
{
    // No additional implementation needed for testing
}
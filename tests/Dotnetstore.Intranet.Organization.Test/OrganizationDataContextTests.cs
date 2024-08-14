using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.Organization.Test;

public class OrganizationDataContextTests : DotnetstoreIntranetBase
{
    [Fact]
    public void Context_ShouldHaveUser()
    {
        DataContext.Users.Should().NotBeNull();
    }
}
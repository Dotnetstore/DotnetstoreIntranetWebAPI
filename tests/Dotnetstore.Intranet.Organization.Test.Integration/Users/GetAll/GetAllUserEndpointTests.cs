using System.Net;
using Dotnetstore.Intranet.Organization.Users.GetAll;
using FastEndpoints;
using FastEndpoints.Testing;
using SDK.Dto.Organization.Users.Responses;
using Xunit;
using FluentAssertions;

namespace Dotnetstore.Intranet.Organization.Test.Integration.Users.GetAll;

public class GetAllUserEndpointTests(DotnetstoreIntranetBase dotnetstoreIntranetBase) : TestBase<DotnetstoreIntranetBase>
{
    [Fact]
    public async Task Get_ReturnsOk()
    {
        // Act
        var (rsp, res) = await dotnetstoreIntranetBase.Client.GETAsync<GetAllUserEndpoint, IEnumerable<UserResponse>>();

        // Assert
        rsp.StatusCode.Should().Be(HttpStatusCode.OK);
        res.Should().NotBeNull();
    }
}
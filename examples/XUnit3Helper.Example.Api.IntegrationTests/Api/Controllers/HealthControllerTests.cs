using System.Net;
using XUnit3Helper.Integration;

namespace XUnit3Helper.Example.Api.IntegrationTests.Api.Controllers;

public sealed class HealthControllerTests(MockWebApplicationFactory applicationFactory)
    : BaseControllerTests<Startup, MockWebApplicationFactory>(applicationFactory)
{
    [Theory]
    [InlineData("health/health-check")]
    public async Task HealthCheck(string url)
    {
        using var client = CreateClient();

        var response = await client.GetAsync(url, TestContext.Current.CancellationToken);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}

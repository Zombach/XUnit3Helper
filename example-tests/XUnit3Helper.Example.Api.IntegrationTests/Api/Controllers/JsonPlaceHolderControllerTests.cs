using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using XUnit3Helper.Example.Api.Infrastructure.ExternalApis.JsonPlaceHolder;
using XUnit3Helper.Integration;

namespace XUnit3Helper.Example.Api.IntegrationTests.Api.Controllers;

public sealed class JsonPlaceHolderControllerTests(MockWebApplicationFactory applicationFactory)
    : BaseControllerTests<Startup, MockWebApplicationFactory>(applicationFactory)
{
    [Theory]
    [InlineData("JsonPlaceHolder/posts/")]
    public async Task GetPostsById(string url)
    {
        using var client = CreateClient();

        var response = await client.GetAsync(url + 1, TestContext.Current.CancellationToken);
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var data = await response.Content
            .ReadFromJsonAsync<JsonPlaceHolderResponse>(TestContext.Current.CancellationToken);
    }
}

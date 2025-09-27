using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Refit;
using XUnit3Helper.Common.Impl;
using XUnit3Helper.Example.Api.Infrastructure.ExternalApis.JsonPlaceHolder;
using XUnit3Helper.Integration;

namespace XUnit3Helper.Example.Api.IntegrationTests.Api.Controllers;

public sealed class JsonPlaceHolderControllerTests(MockWebApplicationFactory applicationFactory)
    : BaseControllerTests<Startup, MockWebApplicationFactory>(applicationFactory)
{
    [Theory, CustomAutoData]
    public async Task GetPostsById(JsonPlaceHolderResponse jsonPlaceHolderResponse, int id)
    {
        using var client = CreateClient();

        var clientMock = Services.GetRequiredService<Mock<IJsonPlaceHolderClient>>();
        clientMock.Setup(c => c
                .GetPostsByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ApiResponse<JsonPlaceHolderResponse>(
                new HttpResponseMessage(HttpStatusCode.OK),
                jsonPlaceHolderResponse,
                new RefitSettings()));

        const string url = "JsonPlaceHolder/posts/";
        var response = await client.GetAsync(url + id, TestContext.Current.CancellationToken);
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var data = await response.Content
            .ReadFromJsonAsync<JsonPlaceHolderResponse>(TestContext.Current.CancellationToken);

        data.Should().NotBeNull();
        data.UserId.Should().Be(jsonPlaceHolderResponse.UserId);
        data.Id.Should().Be(jsonPlaceHolderResponse.Id);
        data.Title.Should().Be(jsonPlaceHolderResponse.Title);
        data.Body.Should().Be(jsonPlaceHolderResponse.Body);
    }
}

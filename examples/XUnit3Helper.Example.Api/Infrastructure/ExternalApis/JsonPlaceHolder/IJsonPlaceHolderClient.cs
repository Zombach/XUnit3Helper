using Microsoft.AspNetCore.Mvc;
using Refit;

namespace XUnit3Helper.Example.Api.Infrastructure.ExternalApis.JsonPlaceHolder;

internal interface IJsonPlaceHolderClient
{
    [Get("/posts/{id}")]
    public Task<ApiResponse<JsonPlaceHolderResponse>> GetPostsByIdAsync(
        [FromQuery] int id,
        CancellationToken cancellationToken = default);
}

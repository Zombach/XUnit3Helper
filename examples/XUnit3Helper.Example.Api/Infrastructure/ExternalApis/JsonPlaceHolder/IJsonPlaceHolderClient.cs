using Microsoft.AspNetCore.Mvc;
using Refit;

namespace XUnit3Helper.Example.Api.Infrastructure.ExternalApis.JsonPlaceHolder;

public interface IJsonPlaceHolderClient
{
    [Get("/posts/{id}")]
    public Task<ApiResponse<JsonPlaceHolderResponse>> GetPostsByIdAsync(
        [FromQuery] int id,
        CancellationToken cancellationToken = default);
}

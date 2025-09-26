using MediatR;
using Microsoft.AspNetCore.Mvc;
using XUnit3Helper.Example.Api.Api.Controllers.Common;
using XUnit3Helper.Example.Api.Application.Features.JsonPlaceHolder;

namespace XUnit3Helper.Example.Api.Api.Controllers;

public sealed class JsonPlaceHolderController(ISender sender)
    : BaseController
{
    [HttpGet]
    [Route("/posts/{id}")]
    public async Task<IActionResult> GetPostsById(
        [FromRoute] int id,
        CancellationToken cancellationToken = default)
    {
        var query = new GetPostsByIdQuery(id);
        var result = await sender.Send(query, cancellationToken);
        return Ok(result.Value);
    }
}

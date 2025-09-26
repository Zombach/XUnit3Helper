using MediatR;
using Microsoft.AspNetCore.Mvc;
using XUnit3Helper.Example.Api.Api.Controllers.Common;
using XUnit3Helper.Example.Api.Application.Features.Health;

namespace XUnit3Helper.Example.Api.Api.Controllers;

[Route("[controller]")]
public sealed class HealthController(ISender sender)
    : BaseController
{
    [HttpGet]
    [Route("health-check")]
    public async Task<ActionResult<DateTimeOffset>> HealthCheck(CancellationToken cancellationToken = default)
    {
        var query = new HealthCheckQuery();
        var result = await sender.Send(query, cancellationToken);
        return Ok(result.Value);
    }
}

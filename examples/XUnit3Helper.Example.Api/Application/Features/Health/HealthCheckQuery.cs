using ErrorOr;
using Mediator;
using XUnit3Helper.Example.Api.Application.Features.Common;

namespace XUnit3Helper.Example.Api.Application.Features.Health;

internal sealed record HealthCheckQuery
    : IRequest<ErrorOr<DateTimeOffset>>
{
    internal sealed class Handler(ILogger<HealthCheckQuery> logger)
        : BaseHandler<HealthCheckQuery, DateTimeOffset>(logger)
    {
        protected override ValueTask<ErrorOr<DateTimeOffset>> HandlerInternal(
            HealthCheckQuery request,
            CancellationToken cancellationToken)
        {
            return ValueTask.FromResult<ErrorOr<DateTimeOffset>>(DateTimeOffset.UtcNow);
        }
    }
}

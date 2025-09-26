using ErrorOr;
using MediatR;
using XUnit3Helper.Example.Api.Application.Features.Common;

namespace XUnit3Helper.Example.Api.Application.Features.Health;

internal sealed record HealthCheckQuery
    : IRequest<ErrorOr<DateTimeOffset>>
{
    internal sealed class Handler(ILogger<HealthCheckQuery> logger)
        : BaseHandler<HealthCheckQuery, DateTimeOffset>(logger)
    {
        protected override Task<ErrorOr<DateTimeOffset>> HandlerInternal(
            HealthCheckQuery request,
            CancellationToken cancellationToken)
        {
            return Task.FromResult<ErrorOr<DateTimeOffset>>(DateTimeOffset.UtcNow);
        }
    }
}

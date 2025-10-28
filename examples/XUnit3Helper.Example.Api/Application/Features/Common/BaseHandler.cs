using ErrorOr;
using Mediator;

namespace XUnit3Helper.Example.Api.Application.Features.Common;

internal abstract class BaseHandler<TRequest>(ILogger logger)
    : BaseHandler<TRequest, Success>(logger)
    where TRequest : IRequest<ErrorOr<Success>>;

internal abstract class BaseHandler<TRequest, TResult>(ILogger logger)
    : IRequestHandler<TRequest, ErrorOr<TResult>>
    where TRequest : IRequest<ErrorOr<TResult>>
    where TResult : notnull
{
    protected ILogger Logger => logger;

    protected abstract ValueTask<ErrorOr<TResult>> HandlerInternal(
        TRequest request,
        CancellationToken cancellationToken);

    public virtual async ValueTask<ErrorOr<TResult>> Handle(
        TRequest request,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return await HandlerInternal(request, cancellationToken);
        }
        catch (Exception exception)
        {
            return Error.Failure(exception.Message);
        }
    }
}

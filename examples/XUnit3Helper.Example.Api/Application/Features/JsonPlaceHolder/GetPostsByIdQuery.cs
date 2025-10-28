using ErrorOr;
using Mediator;
using XUnit3Helper.Example.Api.Application.Features.Common;
using XUnit3Helper.Example.Api.Infrastructure.ExternalApis.JsonPlaceHolder;

namespace XUnit3Helper.Example.Api.Application.Features.JsonPlaceHolder;

internal sealed record GetPostsByIdQuery(int Id)
    : IRequest<ErrorOr<JsonPlaceHolderResponse>>
{
    internal sealed class Handler(
        IJsonPlaceHolderClient jsonPlaceHolderClient,
        ILogger<GetPostsByIdQuery> logger)
        : BaseHandler<GetPostsByIdQuery, JsonPlaceHolderResponse>(logger)
    {
        protected override async ValueTask<ErrorOr<JsonPlaceHolderResponse>> HandlerInternal(
            GetPostsByIdQuery request,
            CancellationToken cancellationToken)
        {
            var response = await jsonPlaceHolderClient.GetPostsByIdAsync(request.Id, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return response.Content;
            }

            return Error.Failure("");
        }
    }
}

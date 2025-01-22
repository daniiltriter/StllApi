using Stll.Commands.Commands;
using Stll.CQRS.Abstractions;
using Stll.CQRS.Results;

namespace Stll.CQRS.Handlers;

public abstract class GetCatcherHandler<TRequest, TModel> : ICatcherHandler<TRequest, GetCatcherResult<TModel>>
    where TRequest : GetCatcherRequest<TModel>
    where TModel : IBusinessModel
{
    public abstract Task<GetCatcherResult<TModel>> ExecuteAsync(TRequest request,
        CancellationToken cancellationToken);
}
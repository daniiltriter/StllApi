using Stll.CQRS.Abstractions;
using Stll.CQRS.Commands;
using Stll.CQRS.Results;

namespace Stll.CQRS.Handlers;

public abstract class FindCatcherHandler<TRequest, TModel> : ICatcherHandler<TRequest, FindCatcherResult<TModel>>
     where TRequest : FindCatcherRequest<TModel>
     where TModel : IBusinessModel
{
    public abstract Task<FindCatcherResult<TModel>> ExecuteAsync(TRequest request,
        CancellationToken cancellationToken);
}
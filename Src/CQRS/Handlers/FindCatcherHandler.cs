using Stll.CQRS.Abstractions;
using Stll.CQRS.Commands;
using Stll.CQRS.Results;

namespace Stll.CQRS.Handlers;

public abstract class FindCatcherHandler<TModel> : ICatcherHandler<FindCatcherRequest<TModel>, FindCatcherResult<TModel>>
     where TModel : IBusinessModel
{
    public abstract Task<FindCatcherResult<TModel>> ExecuteAsync(FindCatcherRequest<TModel> request,
        CancellationToken cancellationToken);
}
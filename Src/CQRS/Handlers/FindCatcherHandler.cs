using Stll.CQRS.Abstractions;
using Stll.CQRS.Commands;
using Stll.CQRS.Results;

namespace Stll.CQRS.Handlers;

public abstract class FindCatcherHandler<TEntity> : ICatcherHandler<FindCatcherCommand<TEntity>, FindCatcherResult<TEntity>>
{
    public abstract Task<FindCatcherResult<TEntity>> HandleAsync(FindCatcherCommand<TEntity> command,
        CancellationToken cancellationToken);
}
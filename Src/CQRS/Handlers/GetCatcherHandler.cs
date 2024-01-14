using Stll.Commands.Commands;
using Stll.CQRS.Abstractions;
using Stll.CQRS.Results;

namespace Stll.CQRS.Handlers;

public abstract class GetCatcherHandler<TEntity> : ICatcherHandler<GetCatcherCommand<TEntity>, GetCatcherResult<TEntity>>
{
    public abstract Task<GetCatcherResult<TEntity>> HandleAsync(GetCatcherCommand<TEntity> command,
        CancellationToken cancellationToken);
}
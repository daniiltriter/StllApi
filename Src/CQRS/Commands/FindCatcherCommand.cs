using Stll.CQRS.Abstractions;
using Stll.CQRS.Results;

namespace Stll.CQRS.Commands;

public class FindCatcherCommand<TEntity> : AbstractCatcherCommand<FindCatcherResult<TEntity>>
{
    public ulong Id { get; set; }

    public FindCatcherCommand(ulong id)
    {
        Id = id;
    }
}
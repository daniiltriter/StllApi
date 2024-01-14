using Stll.CQRS.Abstractions;

namespace Stll.CQRS.Commands;

public abstract class FindCatcherRequest<TEntity> : AbstractCatcherCommand
{
    public ulong Id { get; set; }

    public FindCatcherRequest(ulong id)
    {
        Id = id;
    }
}
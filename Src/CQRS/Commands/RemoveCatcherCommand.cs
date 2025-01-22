using Stll.CQRS.Abstractions;

namespace Stll.CQRS.Commands;

public abstract class RemoveCatcherCommand : AbstractCatcherCommand
{
    public ulong Id { get; set; }

    public RemoveCatcherCommand(ulong id)
    {
        Id = id;
    }
}
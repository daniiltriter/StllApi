using Stll.CQRS.Abstractions;
using Stll.CQRS.Results;

namespace Stll.CQRS.Commands;

public class RemoveCatcherCommand : AbstractCatcherCommand<RemoveCatcherResult>
{
    public ulong Id { get; set; }

    public RemoveCatcherCommand(ulong id)
    {
        Id = id;
    }
}
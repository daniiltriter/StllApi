using Stll.CQRS.Abstractions;
using Stll.CQRS.Commands;
using Stll.CQRS.Results;

namespace Stll.CQRS.Handlers;

public abstract class RemoveCatcherHandler : ICatcherHandler<RemoveCatcherCommand, RemoveCatcherResult>
{
    public abstract Task<RemoveCatcherResult> HandleAsync(RemoveCatcherCommand command,
        CancellationToken cancellationToken);
}
using Stll.Commands.Commands;
using Stll.CQRS.Abstractions;
using Stll.CQRS.Results;

namespace Stll.CQRS.Handlers;

public abstract class CreateCatcherHandler<TCommand> : ICatcherHandler<TCommand, CreateCatcherResult>
    where TCommand : CreateCatcherCommand
{
    public abstract Task<CreateCatcherResult> HandleAsync(TCommand command, CancellationToken cancellationToken);
}
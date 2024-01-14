using Stll.CQRS.Abstractions;
using Stll.CQRS.Commands;
using Stll.CQRS.Results;

namespace Stll.CQRS.Handlers;

public abstract class UpdateCatcherHandler : ICatcherHandler<UpdateCatcherCommand, UpdateCatcherResult>
{
    public abstract Task<UpdateCatcherResult> ExecuteAsync(UpdateCatcherCommand command, 
        CancellationToken cancellationToken);
}
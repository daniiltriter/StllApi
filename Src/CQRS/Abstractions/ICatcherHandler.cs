namespace Stll.CQRS.Abstractions;

public interface ICatcherHandler<in TCommand, TResult>
    where TCommand : AbstractCatcherCommand<TResult>
    where TResult : AbstractCatcherResult, new()
{
    Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken);
}
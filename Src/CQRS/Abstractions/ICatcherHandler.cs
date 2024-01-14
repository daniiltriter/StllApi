namespace Stll.CQRS.Abstractions;

public interface ICatcherHandler<TCommand, TResult>
    where TCommand : AbstractCatcherCommand
    where TResult : AbstractCatcherResult
{
    Task<TResult> ExecuteAsync(TCommand command, CancellationToken cancellationToken);
}
namespace Stll.CQRS.Abstractions;

public interface ICatcher
{
   Task<TResult> SafeExecuteAsync<TCommand, TResult>(TCommand command) 
      where TResult : AbstractCatcherResult, new()
      where TCommand : AbstractCatcherCommand<TResult>;
}
namespace Stll.WebAPI.Commands;

public interface ICatcher
{
   Task<TResult> SafeExecuteAsync<TResult>(CatcherCommand<TResult> command) where TResult : CatcherResult, new();
}
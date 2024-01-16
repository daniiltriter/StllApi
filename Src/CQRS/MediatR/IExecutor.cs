using MediatR;

namespace Stll.CQRS.Abstractions;

public interface IExecutor
{
    Task<TResult> SafeExecuteAsync<TResult>(IExecutorRequest<TResult> request)
        where TResult : AbstractHandlerResult, new();
}
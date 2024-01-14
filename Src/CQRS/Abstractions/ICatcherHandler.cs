using MediatR;

namespace Stll.WebAPI.Commands;

public interface ICatcherHandler<TResult> : IRequestHandler<CatcherCommand<TResult>, TResult>
    where TResult : AbstractCatcherResult, new()
{
    async Task<TResult> IRequestHandler<CatcherCommand<TResult>, TResult>.Handle(CatcherCommand<TResult> request, 
        CancellationToken cancellationToken)
    {
        return await ExecuteAsync(request);
    }

    Task<TResult> ExecuteAsync(CatcherCommand<TResult> request);
}
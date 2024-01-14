using MediatR;

namespace Stll.WebAPI.Commands;

public interface ICatcherHandler<TResult>: IRequestHandler<CatcherCommand<TResult>, TResult>
{
    Task<TResult> ExecuteAsync(CatcherCommand<TResult> command);
    private async Task<TResult> Handle(CatcherCommand<TResult> request, CancellationToken cancellationToken)
    {
        return await ExecuteAsync(request);
    }
}
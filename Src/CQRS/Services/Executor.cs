using MediatR;
using Stll.CQRS.Abstractions;

namespace Stll.CQRS.Services;

// TODO: make my own mediator)
public class Executor : IExecutor
{
    private readonly IMediator _mediator;
    public Executor(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<TResult> SafeExecuteAsync<TResult>(IExecutorRequest<TResult> request)
        where TResult : AbstractHandlerResult, new()
    {
        try
        {
            var handleResult = await _mediator.Send(request);
            return handleResult;
        }
        catch (Exception ex)
        {
            var result = new TResult
            {
                Error = ex.Message,
                Processed = false
            };

            return result;
        }
    }
}
using MediatR;

namespace Stll.WebAPI.Commands.Services;

public class MediatorCatcher : ICatcher
{
    private readonly IMediator _mediator;
    
    public MediatorCatcher(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<TResult> SafeExecuteAsync<TResult>(CatcherCommand<TResult> command) where TResult : CatcherResult, new()
    {
        try
        {
            var handleResult = await _mediator.Send(command);
            return handleResult;
        }
        catch (Exception ex)
        {
            var errorResult = new TResult();
            errorResult.HasError = true;
            errorResult.ErrorMessage = ex.Message;
            return errorResult;
        }
    }
}
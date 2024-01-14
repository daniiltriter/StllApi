using MediatR;
using Stll.CQRS.Abstractions;

namespace Stll.CQRS.Services;

public class MediatorCatcher : ICatcher
{
    private readonly IServiceProvider _services;
    //private readonly IDictionary<Type, Type> _handlers = new Dictionary<Type, Type>();

    public MediatorCatcher(IServiceProvider services)
    {
        _services = services;
    }
    
    public async Task<TResult> SafeExecuteAsync<TCommand, TResult>(TCommand command) 
        where TResult : AbstractCatcherResult, new()
        where TCommand : AbstractCatcherCommand<TResult>
    {
        try
        {
            var handlerType = typeof(ICatcherHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
            var handlerService = _services.GetService(handlerType) ;
            var handler = handlerService as ICatcherHandler<TCommand, TResult>;
            return await handler.HandleAsync(command, new CancellationToken());
        }
        catch (Exception ex)
        {
            var errorResult = new TResult();
            errorResult.Processed = false;
            errorResult.ErrorMessage = ex.Message;
            return errorResult;
        }
    }
}
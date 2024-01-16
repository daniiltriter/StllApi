using Stll.Commands.Commands;
using Stll.CQRS.Abstractions;
using Stll.CQRS.Commands;
using Stll.CQRS.Results;

namespace Stll.CQRS.Services;

public class BusinessExecutor : IBusinessExecutor
{
    private readonly IServiceProvider _services;
    //private readonly IDictionary<Type, Type> _handlers = new Dictionary<Type, Type>();

    public BusinessExecutor(IServiceProvider services)
    {
        _services = services;
    }

    public async Task<CreateCatcherResult> SendForCreateAsync<TCommand>(TCommand command) 
        where TCommand : CreateCatcherCommand
    {
        throw new NotImplementedException();
    }


    public async Task<GetCatcherResult<TModel>> GetSendAsync<TRequest, TModel>(TRequest request) 
        where TRequest : GetCatcherRequest<TModel>
        where TModel : IBusinessModel
    {
        try
        {
            var handlerType = typeof(ICatcherHandler<,>).MakeGenericType(request.GetType(), typeof(GetCatcherResult<TModel>));
            var handlerService = _services.GetService(handlerType) ;
            var handler = (ICatcherHandler<TRequest, GetCatcherResult<TModel>>)handlerService;
            return await handler.ExecuteAsync(request, new CancellationToken());
        }
        catch (Exception ex)
        {
            var errorResult = new GetCatcherResult<TModel>();
            errorResult.Processed = false;
            errorResult.ErrorMessage = ex.Message;
            return errorResult;
        }
    }

    public async Task<FindCatcherResult<TModel>> FindSendAsync<TRequest, TModel>(TRequest request) 
        where TRequest : FindCatcherRequest<TModel>
        where TModel : IBusinessModel
    {
        try
        {
            var handlerType = typeof(ICatcherHandler<,>).MakeGenericType(request.GetType(), typeof(FindCatcherResult<TModel>));
            var handlerService = _services.GetService(handlerType) ;
            var handler = (ICatcherHandler<TRequest, FindCatcherResult<TModel>>)handlerService;
            return await handler.ExecuteAsync(request, new CancellationToken());
        }
        catch (Exception ex)
        {
            return FindCatcherResult<TModel>.Failed(ex.Message);
        }
    }

    public Task<RemoveCatcherResult> RemoveSendAsync<TCommand>(TCommand command) where TCommand : RemoveCatcherCommand
    {
        throw new NotImplementedException();
    }

    public Task<UpdateCatcherResult> UpdateSendAsync<TCommand>(TCommand command) where TCommand : CreateCatcherCommand
    {
        throw new NotImplementedException();
    }

    public async Task<CreateCatcherResult> CreateSendAsync<TCommand>(TCommand command) where TCommand : CreateCatcherCommand
    {
        try
        {
            var handlerType = typeof(ICatcherHandler<,>).MakeGenericType(command.GetType(), typeof(CreateCatcherResult));
            var handlerService = _services.GetService(handlerType) ;
            var handler = (ICatcherHandler<TCommand, CreateCatcherResult>)handlerService;
            return await handler.ExecuteAsync(command, new CancellationToken());
        }
        catch (Exception ex)
        {
            return CreateCatcherResult.Failed(ex.Message);
        }
    }

    public async Task<TResult> ExecuteAsync<TCommand, TResult>(TCommand command) 
        where TResult : AbstractCatcherResult, new()
        where TCommand : AbstractCatcherCommand
    {
        try
        {
            var handlerType = typeof(ICatcherHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
            var handlerService = _services.GetService(handlerType) ;
            var handler = (ICatcherHandler<TCommand, TResult>)handlerService;
            return await handler.ExecuteAsync(command, new CancellationToken());
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
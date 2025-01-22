using Stll.Commands.Commands;
using Stll.CQRS.Commands;
using Stll.CQRS.Results;

namespace Stll.CQRS.Abstractions;

public interface IBusinessExecutor
{
    Task<GetCatcherResult<TModel>> GetSendAsync<TRequest, TModel>(TRequest request)
        where TRequest : GetCatcherRequest<TModel>
        where TModel : IBusinessModel;

    Task<FindCatcherResult<TModel>> FindSendAsync<TRequest, TModel>(TRequest request)
        where TRequest : FindCatcherRequest<TModel>
        where TModel : IBusinessModel;
    
    Task<RemoveCatcherResult> RemoveSendAsync<TCommand>(TCommand command)
        where TCommand : RemoveCatcherCommand;
    
    Task<UpdateCatcherResult> UpdateSendAsync<TCommand>(TCommand command)
        where TCommand : CreateCatcherCommand;
    
    Task<CreateCatcherResult> CreateSendAsync<TCommand>(TCommand command)
        where TCommand : CreateCatcherCommand;
    
   Task<TResult> ExecuteAsync<TCommand, TResult>(TCommand command) 
      where TResult : AbstractCatcherResult, new()
      where TCommand : AbstractCatcherCommand;
}
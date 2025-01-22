using MediatR;

namespace Stll.CQRS.Abstractions;

public interface IExecutorRequest<out TResult> : IRequest<TResult> 
    where TResult: AbstractHandlerResult
{
    
}
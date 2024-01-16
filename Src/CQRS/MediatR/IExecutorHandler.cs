using MediatR;

namespace Stll.CQRS.Abstractions;

public interface IExecutorHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse> 
    where TRequest : IExecutorRequest<TResponse> 
    where TResponse : AbstractHandlerResult
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}
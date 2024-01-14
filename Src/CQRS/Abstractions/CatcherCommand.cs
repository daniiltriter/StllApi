using MediatR;

namespace Stll.WebAPI.Commands;

public abstract class CatcherCommand<TResult> : IRequest<TResult>
{}
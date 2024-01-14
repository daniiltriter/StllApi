using Stll.CQRS.Abstractions;
using Stll.CQRS.Results;

namespace Stll.Commands.Commands;

public class GetCatcherCommand<TEntity> : AbstractCatcherCommand<GetCatcherResult<TEntity>>
{}
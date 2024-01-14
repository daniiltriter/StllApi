using Stll.CQRS.Abstractions;

namespace Stll.CQRS.Results;

public class FindCatcherResult<TEntity> : AbstractCatcherResult
{ 
    public TEntity Entity { get; set; }
}
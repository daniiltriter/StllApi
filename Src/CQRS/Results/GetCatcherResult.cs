using Stll.CQRS.Abstractions;

namespace Stll.CQRS.Results;

public class GetCatcherResult<TEntity> : AbstractCatcherResult
{
    public ICollection<TEntity> Entities { get; set; } 
}
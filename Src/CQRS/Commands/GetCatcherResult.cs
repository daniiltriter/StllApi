using Stll.WebAPI.Commands;

namespace Stll.CQRS.Commands;

public class GetCatcherResult<TEntity> : AbstractCatcherResult
{
    public ICollection<TEntity> Entities { get; set; } 
}
using Stll.WebAPI.Commands;

namespace Stll.Commands.Commands;

public class GetCatcherResult<TEntity> : CatcherResult
{
    public ICollection<TEntity> Entities { get; set; } 
}
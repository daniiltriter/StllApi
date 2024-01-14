namespace Stll.WebAPI.Commands;

public class FindCatcherResult<TEntity> : AbstractCatcherResult
{ 
    public TEntity Entity { get; set; }
}
namespace Stll.WebAPI.Commands;

public class FindCatcherResult<TEntity> : CatcherResult
{ 
    public TEntity Entity { get; set; }
}
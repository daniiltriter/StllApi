using Stll.CQRS.Abstractions;

namespace Stll.CQRS.Results;

public class GetCatcherResult<TEntity> : AbstractCatcherResult
    where TEntity : IBusinessModel
{
    public ICollection<TEntity> Entities { get; set; }

    public static GetCatcherResult<TEntity> Success(ICollection<TEntity> models) => new()
    {
        Entities = models,
        Processed = true,
        ErrorMessage = null
    };
    
    public static GetCatcherResult<TEntity> Failed(string error) => new()
    {
        Entities = null,
        Processed = false,
        ErrorMessage = error
    };
}
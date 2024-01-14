using Stll.CQRS.Abstractions;

namespace Stll.CQRS.Results;

public class FindCatcherResult<TModel> : AbstractCatcherResult 
    where TModel : IBusinessModel
{ 
    public TModel Model { get; set; }
    
    public static FindCatcherResult<TModel> Success(TModel model) => new()
    {
        Model = model,
        Processed = true,
        ErrorMessage = null
    };
    
    public static FindCatcherResult<TModel> Failed(string error) => new()
    {
        Model = null,
        Processed = false,
        ErrorMessage = error
    };
}
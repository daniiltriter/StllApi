using Stll.CQRS.Abstractions;

namespace Stll.WebAPI.Commands;

public class FindHandlerResult<TModel> : AbstractHandlerResult where TModel : class
{
    public TModel Model { get; set; }

    public static FindHandlerResult<TModel> Success(TModel model) => new()
    {
        Model = model,
        Processed = true,
        Error = null
    };

    public static FindHandlerResult<TModel> Failed(string error) => new()
    {
        Model = default,
        Error = error,
        Processed = false
    };
}
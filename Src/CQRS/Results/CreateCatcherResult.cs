using Stll.CQRS.Abstractions;

namespace Stll.CQRS.Results;

public class CreateCatcherResult : AbstractCatcherResult
{
    public ulong CreatedId { get; set; }

    public static CreateCatcherResult Success(ulong createdId) => new()
    {
        CreatedId = createdId,
        ErrorMessage = null,
        Processed = true
    };
    
    public static CreateCatcherResult Failed(string error) => new()
    {
        CreatedId = 0,
        ErrorMessage = error,
        Processed = false
    };
}
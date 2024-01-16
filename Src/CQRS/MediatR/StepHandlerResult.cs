using Stll.CQRS.Abstractions;

namespace Stll.CQRS.Results;

public class StepHandlerResult : AbstractHandlerResult
{
    public static StepHandlerResult Success() => new()
    {
        Processed = true,
        Error = null
    };

    public static StepHandlerResult Failed(string error) => new()
    {
        Processed = false,
        Error = error
    };
}
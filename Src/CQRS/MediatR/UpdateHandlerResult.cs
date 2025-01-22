using Stll.CQRS.Abstractions;

namespace Stll.WebAPI.Commands;

public class UpdateHandlerResult : AbstractHandlerResult
{
    public uint AffectedCount { get; set; }

    public static UpdateHandlerResult Success(uint affectedCount) => new()
    {
        AffectedCount = affectedCount,
        Processed = true,
        Error = null
    };

    public static UpdateHandlerResult Failed(string error) => new()
    {
        AffectedCount = 0,
        Processed = false,
        Error = error
    };
}
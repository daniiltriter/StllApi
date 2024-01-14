using Stll.WebAPI.Commands;

namespace Stll.Commands.Commands;

public class UpdateCatcherResult : CatcherResult
{
    public uint AffectedCount { get; set; }
}
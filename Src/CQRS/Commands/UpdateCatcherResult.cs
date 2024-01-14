using Stll.WebAPI.Commands;

namespace Stll.CQRS.Commands;

public class UpdateCatcherResult : AbstractCatcherResult
{
    public uint AffectedCount { get; set; }
}
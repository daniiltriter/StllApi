using Stll.CQRS.Abstractions;

namespace Stll.CQRS.Results;

public class UpdateCatcherResult : AbstractCatcherResult
{
    public uint AffectedCount { get; set; }
}
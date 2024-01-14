using Stll.CQRS.Abstractions;

namespace Stll.CQRS.Results;

public class CreateCatcherResult : AbstractCatcherResult
{
    public ulong CreatedId { get; set; }
}
using Stll.WebAPI.Commands;

namespace Stll.CQRS.Commands;

public class CreateCatcherResult : AbstractCatcherResult
{
    public ulong CreatedId { get; set; }
}
using Stll.WebAPI.Commands;

namespace Stll.Commands.Commands;

public class CreateCatcherResult : CatcherResult
{
    public ulong CreatedId { get; set; }
}
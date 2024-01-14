using Stll.CQRS.Commands;
using Stll.WebAPI.Commands;

namespace Commands.Tests.Handlers;

public class CreatePingHandler : ICatcherHandler<CreateCatcherResult>
{
    public async Task<CreateCatcherResult> ExecuteAsync(CatcherCommand<CreateCatcherResult> request)
    {
        var result = new CreateCatcherResult
        {
            CreatedId = 1,
            Processed = false,
            ErrorMessage = null
        };

        return result;
    }
}
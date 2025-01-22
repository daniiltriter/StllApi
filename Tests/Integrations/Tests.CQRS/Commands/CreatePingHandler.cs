using Stll.CQRS.Handlers;
using Stll.CQRS.Results;

namespace Stll.Tests.CQRS.Commands;

public class CreatePingHandler : CreateCatcherHandler<CreatePingCommand>
{
    public override Task<CreateCatcherResult> ExecuteAsync(CreatePingCommand command, CancellationToken cancellationToken)
    {
        var result = new CreateCatcherResult()
        {
            Processed = true,
            CreatedId = 1,
            ErrorMessage = null
        };
        return Task.FromResult(result);
    }
}
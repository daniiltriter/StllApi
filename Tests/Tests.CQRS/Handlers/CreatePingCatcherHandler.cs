using Commands.Tests.Commands;
using Stll.CQRS.Handlers;
using Stll.CQRS.Results;

namespace Commands.Tests.Handlers;

public class CreatePingHandler : CreateCatcherHandler<CreatePingCommand>
{
    public override Task<CreateCatcherResult> HandleAsync(CreatePingCommand command, CancellationToken cancellationToken)
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
using Stll.CQRS.Handlers;
using Stll.CQRS.Results;
using Stll.Tests.CQRS.Models;

namespace Stll.Tests.CQRS.Requests;

public class GetPingHandler : GetCatcherHandler<GetPingRequest, PingModel>
{
    public override Task<GetCatcherResult<PingModel>> ExecuteAsync(GetPingRequest request, CancellationToken cancellationToken)
    {
        var models = new List<PingModel>
        {
            new() { Content = nameof(PingModel) }
        };
        var result = GetCatcherResult<PingModel>.Success(models);

        return Task.FromResult(result);
    }
}
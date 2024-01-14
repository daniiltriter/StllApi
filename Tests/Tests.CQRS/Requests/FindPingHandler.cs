using Stll.CQRS.Commands;
using Stll.CQRS.Handlers;
using Stll.CQRS.Results;
using Stll.Tests.CQRS.Models;

namespace Stll.Tests.CQRS.Requests;

public class FindPingHandler : FindCatcherHandler<PingModel>
{
    public override Task<FindCatcherResult<PingModel>> ExecuteAsync(FindCatcherRequest<PingModel> request, 
        CancellationToken cancellationToken)
    {
        var tempStorage = new Dictionary<ulong, PingModel>
        {
            { 1, new(){ Content = nameof(PingModel) } }
        };
        var model = tempStorage[request.Id];

        var result = FindCatcherResult<PingModel>.Success(model);
        return Task.FromResult(result);
    }
}
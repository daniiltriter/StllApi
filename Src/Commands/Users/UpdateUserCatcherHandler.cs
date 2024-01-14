using Stll.CQRS.Commands;
using Stll.Domain.Abstractions;
using Stll.WebAPI.Commands;

namespace Stll.Commands.Users;

public class UpdateUserCatcherHandler : ICatcherHandler<UpdateCatcherResult>
{
    private readonly IDomainService _domain;
    public UpdateUserCatcherHandler(IDomainService domain)
    {
        _domain = domain;
    }

    public Task<UpdateCatcherResult> ExecuteAsync(CatcherCommand<UpdateCatcherResult> request)
    {
        throw new NotImplementedException();
    }
}
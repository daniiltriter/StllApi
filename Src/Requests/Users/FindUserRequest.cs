using Requests.Users;
using Stll.CQRS.Abstractions;
using Stll.WebAPI.Commands;

namespace Stll.Requests.Users;

public class FindUserRequest : IExecutorRequest<FindHandlerResult<UserDto>>
{
    public ulong Id { get; set; }
    public FindUserRequest(ulong id)
    {
        Id = id;
    }
}
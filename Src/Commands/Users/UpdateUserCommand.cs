using Stll.CQRS.Abstractions;
using Stll.WebAPI.Commands;

namespace Stll.Commands.Users;

public class UpdateUserCommand : IExecutorRequest<UpdateHandlerResult>
{
    public ulong Id { get; set; }
    public string Name { get; set; } 
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}
using Stll.CQRS.Abstractions;
using Stll.WebAPI.Commands;

namespace Stll.Commands.Users;

public class RegisterUserCommand : IExecutorRequest<CreateHandlerResult>
{
    public string Name { get; set; }
    public string Password { get; set; }
}
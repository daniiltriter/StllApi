using MediatR;
using Stll.Core.Commands;

namespace Stll.CQRS.Commands.Users;

public class RegisterUserCommand : IRequest<CreateHandlerResult>
{
    public string Name { get; set; }
    public string Password { get; set; }
}
using MediatR;
using Stll.WebAPI.Commands;

namespace Stll.Commands.Users;

public class RegisterUserCommand : IRequest<CreateHandlerResult>
{
    public string Name { get; set; }
    public string Password { get; set; }
}
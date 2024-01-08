using MediatR;

namespace Stll.Core.Commands.Users;

public class RegisterUserCommand : IRequest
{
    public string Name { get; set; }
    public string Password { get; set; }
}
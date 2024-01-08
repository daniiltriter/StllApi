using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stll.Core.Commands.Users;
using Stll.Core.Views.Users;

namespace Stll.Core.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<ActionResult> Register([FromBody] RegisterUserEndpointRequest request)
    {
        var command = new RegisterUserCommand()
        {
            Name = request.Name,
            Password = request.Password
        };
        var handleResult = await _mediator.Send(command);
        return Ok(handleResult);
    }
}
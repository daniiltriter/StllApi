using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stll.CQRS.Commands.Users;
using Stll.Domain.Abstractions;
using Stll.WebAPI.Views.Users;

namespace Stll.WebAPI.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UsersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<string>> GetAsync()
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<ActionResult> Register([FromBody] RegisterUserEndpointRequest request)
    {
        var command = _mapper.Map<RegisterUserCommand>(request);
        var handleResult = await _mediator.Send(command);
        
        if (!handleResult.Processed)
        {
            return BadRequest(handleResult.Error);
        }
        
        return Ok(handleResult);
    }
}
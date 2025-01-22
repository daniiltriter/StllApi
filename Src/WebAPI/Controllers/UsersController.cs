using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stll.Commands.Users;
using Stll.CQRS.Abstractions;
using Stll.Requests.Users;
using Stll.WebAPI.Views.Users;

namespace Stll.WebAPI.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IExecutor _executor;

    public UsersController(IMediator mediator, IMapper mapper, IExecutor executor)
    {
        _mediator = mediator;
        _mapper = mapper;
        _executor = executor;
    }

    [HttpPatch]
    [Authorize]
    public async Task<ActionResult> UpdateAsync(UpdateUserEndpointRequest request)
    {
        var preparedCommand = _mapper.Map(request, new UpdateUserCommand());
        
        var executeResult = await _executor.SafeExecuteAsync(preparedCommand);
        if (!executeResult.Processed)
        {
            return BadRequest(executeResult.Error);
        }

        return Ok(executeResult);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<UserViewModel>> GetByIdAsync(ulong id)
    {
        // TODO: make a service for Actor info getting
        var request = new FindUserRequest(id);
        var executeResult = await _executor.SafeExecuteAsync(request);
        if (!executeResult.Processed)
        {
            return BadRequest(executeResult.Error);
        }

        var view = _mapper.Map<UserViewModel>(executeResult.Model);
        return Ok(view);
    }
    
    [HttpPost]
    public async Task<ActionResult> RegisterAsync([FromBody] RegisterUserEndpointRequest request)
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
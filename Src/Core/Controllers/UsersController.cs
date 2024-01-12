using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stll.Core.Views.Users;
using Stll.CQRS.Commands.Users;
using Stll.Domain.Abstractions;
using Stll.Types;

namespace Stll.Core.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IDomainService _domain;
    
    public UsersController(IMediator mediator, IMapper mapper, IDomainService domain)
    {
        _mediator = mediator;
        _mapper = mapper;
        _domain = domain;
    }

    [HttpGet]
    //[Authorize]
    public async Task<ActionResult<string>> GetAsync()
    {
        var user = await _domain.GetContextFor<User>().FindAsync(4);
        
        return Ok(user);
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
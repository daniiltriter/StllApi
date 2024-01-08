using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stll.Core.Domain;

namespace Stll.Core.Controllers;

[ApiController]
[Route("api/template")]
[Authorize]
public class TemplateController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok();
    }
}
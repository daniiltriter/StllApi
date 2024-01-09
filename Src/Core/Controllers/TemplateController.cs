using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
using Microsoft.AspNetCore.Mvc;

namespace Stll.Core.Controllers;

[ApiController]
[Route("template")]
public class TemplateController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Hello");
    }
}
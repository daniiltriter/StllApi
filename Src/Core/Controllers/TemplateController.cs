using Microsoft.AspNetCore.Mvc;
using Stll.Core.Domain;

namespace Stll.Core.Controllers;

[ApiController]
[Route("template")]
public class TemplateController : ControllerBase
{
    private readonly ApplicationContext _domainContext;
    public TemplateController(ApplicationContext domainContext)
    {
        _domainContext = domainContext;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Hello");
    }
}
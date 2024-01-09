using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Stll.Core.Controllers;

[ApiController]
[Route("api/files")]
public class FilesController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;
    public FilesController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }
    [HttpGet("java")]
    public async Task<ActionResult> DownloadJava()
    {
        var wwwrootPath = "wwwroot";
        var filePath = Path.Combine(wwwrootPath, "openjdk-17_windows.zip");
        if (System.IO.File.Exists(filePath))
        {
            var fileBytes = System.IO.File.ReadAllBytes(filePath);  
            return File(fileBytes, "application/octet-stream", "openjdk-17_windows.zip");
        }

        return NotFound(filePath);
    }

    [HttpGet("minecraft")]
    public IActionResult DownloadMinecraft()
    {
        return Ok();
    }
}
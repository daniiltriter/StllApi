using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Stll.Shared.Services;
using Stll.Types.Variables;

namespace Stll.Core.Controllers;

[ApiController]
[Route("api/files")]
public class FilesController : ControllerBase
{
    private readonly IFileService _file;
    public FilesController(IFileService file)
    {
        _file = file;
    }
    
    [HttpGet("java")]
    public async Task<ActionResult> DownloadJava()
    {
        var serviceResponse = await _file.AsBytesAsync(IOPaths.WWW_ROOT + IOPaths.WWW_ROOT);
        if (!serviceResponse.Processed)
        {
            return BadRequest(serviceResponse.ErrorMessage);
        }
        
        return File(serviceResponse.Result, HttpDefaults.OCTET_STREAM_HEADER, IOPaths.JAVA_ARCHIVE);
    }

    [HttpGet("minecraft")]
    public IActionResult DownloadMinecraft()
    {
        return Ok();
    }
}
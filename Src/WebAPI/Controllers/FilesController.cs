using Microsoft.AspNetCore.Mvc;
using Stll.WebAPI.Services;
using Stll.Types.Variables;

namespace Stll.WebAPI.Controllers;

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
        // TODO: temp solution. Performance trouble. Use file stream and cancellation token
        var serviceResponse = await _file.AsBytesAsync(IOPaths.WWW_ROOT, IOPaths.JAVA_ARCHIVE);
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
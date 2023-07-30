using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Thulir.ReactUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileUploadController : Controller
{
    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var filePath = Path.GetTempFileName();
        filePath = "/Users/rajanp/file_uploads/";
        
        // filePath = "/tmp/thulirdata";

        var split = file.FileName.Split("_");
        var label = split[0];

        filePath = filePath + label + "/";

        System.IO.Directory.CreateDirectory(filePath);
        
        filePath = filePath + file.FileName;
        
        
        System.Console.WriteLine("Temp file name: ", filePath);
    
        using (var stream = System.IO.File.Create(filePath))
        {
            await file.CopyToAsync(stream);
        }
    
        return Ok(new { count = 1 });
    }
}
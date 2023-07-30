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
        filePath = AspNetConstants.FILE_UPLOAD_FOLDER_NAME;
        
        // filePath = "/tmp/thulirdata";

        var split = file.FileName.Split("_");
        var dataSet = split[0];
        var label = split[1];

        filePath = filePath + dataSet + "/" + label + "/";

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
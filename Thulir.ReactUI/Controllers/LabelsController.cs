using System.Text;
using System.Text.Json;
using Thulir.Core.DbModels;
using Thulir.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Label = Thulir.Core.DbModels.Label;

namespace Thulir.ReactUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LabelsController : ControllerBase
{
    private LabelsRepository _labelsRepository = new LabelsRepository();
    
    [HttpGet]
    public async Task<Label> Get(Guid imageId)
    {
        return null; //_labelsRepository.GetLables(imageId);
    }
    
    [HttpPost]
    public async Task Post(Guid imageId)
    {
        using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
        {  
            var data = await reader.ReadToEndAsync();
            var labels = JsonSerializer.Deserialize<Label[]>(data);

            var imageLabel = new ImageLabel()
            {
                ImageId = imageId,
                Labels = labels.ToList()
            };
            
            await _labelsRepository.SaveLabels(imageId, imageLabel);
        }
    }
}
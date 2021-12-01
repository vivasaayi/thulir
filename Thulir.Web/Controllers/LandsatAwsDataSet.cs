using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thulir.Landsat.Services;

namespace Thulir.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LandsatAwsDataSetController : ControllerBase
    {
        ILandsatDataSource _landsatDataSource = new LandsatDataSource();
        string _level2KeyName = "collection02/level-2/catalog.json";

        [HttpGet("catalog")]
        public async Task<string> catalog()
        {
            var catalog = await _landsatDataSource.ListCatalog(_level2KeyName);
            return JsonSerializer.Serialize(catalog);
        }
        
        [HttpGet("welcome2")]
        public string Welcome2()
        {
            return "This is the Welcome2 action method...";
        }
    }
}
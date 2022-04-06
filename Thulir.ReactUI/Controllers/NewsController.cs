using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thulir.Landsat.Models;
using Thulir.Landsat.Services;
using Thulir.News.Services;

namespace Thulir.ReactUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private INewsService _newsService = new NewsService();

        [HttpGet("list")]
        public async Task<News.Models.News[]> GetNews()
        {
            //await _landsatDataCopier.SyncS3FolderToLocal("/", location);
            var result = await _newsService.GetNews();

            return result;
        }
    }
    
}
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thulir.Landsat.Models;
using Thulir.Landsat.Services;

namespace Thulir.ReactUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LandsatTileGeneratorController : ControllerBase
    {
        private ILandsatDataCopier _landsatDataCopier = new LandsatDataCopier();

        [HttpGet("sync-s3files-to-local-disk")]
        public async Task SyncS3FilesToDis(string? location)
        {
            if (string.IsNullOrEmpty(location))
            {
                location = "/Users/rajanp/tests3sync";
            }
            await _landsatDataCopier.SyncS3FolderToLocal("/", location);
        }
    }
}
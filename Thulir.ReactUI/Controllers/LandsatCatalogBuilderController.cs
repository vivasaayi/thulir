using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thulir.Landsat.Models;
using Thulir.Landsat.Services;

namespace Thulir.ReactUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LandsatCatalogBuilderController : ControllerBase
    {
        private ILandsatCatalogBuilder _landsatCatalogBuilder = new LandsatCatalogBuilder();

        [HttpGet("catalog")]
        public async Task<LandsatCatalog> catalog(string instruments, string years, string paths, string rows)
        {
            var instrumentsList = instruments.Split(",");
            var yearsList = years.Split(",");
            var pathsList = paths.Split(",");
            var rowsList = rows.Split(",");
            
            var catalog = await _landsatCatalogBuilder.BuildCatalog(
                instrumentsList.ToList(),
                yearsList.ToList(),
                pathsList.ToList(),
                rowsList.ToList()
            );
            
            return catalog;
        }

        [HttpGet("indexed-catalog")]
        public async Task<LandsatCatalog> indexedCatalog()
        {
            var catalog = await _landsatCatalogBuilder.GetIndexedCatalog();
            
            return catalog;
        }
    }
}
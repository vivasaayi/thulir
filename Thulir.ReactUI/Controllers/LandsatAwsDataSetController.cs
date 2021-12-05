using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thulir.Landsat.Models;
using Thulir.Landsat.Services;

namespace Thulir.ReactUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LandsatAwsDataSetController : ControllerBase
    {
        ILandsatDataSource _landsatDataSource = new LandsatDataSource();
        private ILandsatDataCopier _landsatDataCopier = new LandsatDataCopier();
        string _level2KeyName = "collection02/level-2/catalog.json";

        [HttpGet("catalog")]
        public async Task<LandsatCatalog> catalog(string? name)
        {
            if (String.IsNullOrEmpty(name))
            {
                name = _level2KeyName;
            }
            var catalog = await _landsatDataSource.ListCatalog(name);
            return catalog;
        }
        
        [HttpGet("catalog/sync-s3")]
        public async Task<List<string>> catalog()
        {
            var pendingFiles = await _landsatDataCopier.SyncS3Files();
            return pendingFiles;
        }
    }
}
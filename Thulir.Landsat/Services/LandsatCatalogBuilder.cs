using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Thulir.Landsat.Models;
using Thulir.Landsat.Repositories;

namespace Thulir.Landsat.Services
{
    public class LandsatCatalogBuilder : ILandsatCatalogBuilder
    {
        private IAwsDataInterface _awsDataInterface;
        private ICatalogRepository _catalogRepository;
        
        string level2KeyName = "collection02/level-2/catalog.json";
        
        private Dictionary<int, List<string>> _levelMaps = new Dictionary<int, List<string>>();

        private List<LandsatCatalogItem> _allItems = new List<LandsatCatalogItem>();

        public LandsatCatalogBuilder()
        {
            _awsDataInterface = new AwsDataInterface();
            _catalogRepository = new CatalogRepository();
        }

        public async Task<LandsatCatalog> GetIndexedCatalog()
        {
            return await _catalogRepository.GetCatalog("dataproducts");
        }
        
        public async Task<LandsatCatalog> BuildCatalog(List<string> instruments, List<string> years, List<string>  paths, List<string>  rows)
        {
            _levelMaps.Add(0, new List<string>()
            {
                "standard"
            });

            _levelMaps.Add(1, instruments);
            _levelMaps.Add(2, years);
            _levelMaps.Add(3, paths);
            _levelMaps.Add(4, rows);

            await GetCatalog(0, level2KeyName);

            var catalog =  new LandsatCatalog()
            {
                Description = "dataproducts",
                Links = _allItems.ToArray()
            };

            await _catalogRepository.SaveCatalog(catalog);

            return catalog;
        }

        public async Task<LandsatCatalog> GetCatalog(int currentLevel, string key)
        {
            var catalog = await _awsDataInterface.ListC2L2DataCatalog(key);

            if (currentLevel == _levelMaps.Count())
            {
                _allItems.AddRange(catalog.Links);
                return catalog;
            }

            var currentLevelMap = _levelMaps[currentLevel];

            var s3KeyName = "";
            
            foreach (var link in catalog.Links)
            {
                if (link.Rel != "child") continue;
                
                if (currentLevelMap.Any())
                {
                    if (currentLevelMap.Exists(s => s == link.Title))
                    {
                        s3KeyName = link.Href.Replace("https://landsatlook.usgs.gov/data/", "");
                        await GetCatalog(currentLevel+1, s3KeyName);
                    } 
                }
                else
                {
                    s3KeyName = link.Href.Replace("https://landsatlook.usgs.gov/data/", "");
                    await  GetCatalog(currentLevel+1, s3KeyName);
                }
            }

            return catalog;
        }
    }
}
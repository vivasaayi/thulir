using System.Collections.Generic;
using System.Threading.Tasks;
using Thulir.Landsat.Services;
namespace Thulir.Cli.Commands
{
    public class LandsatCommands
    {
        private ILandsatCatalogBuilder _landsatCatalogBuilder;
        private ILandsatDataCopier _landsatDataCopier;
        
        public LandsatCommands()
        {
            _landsatCatalogBuilder = new LandsatCatalogBuilder();
            _landsatDataCopier = new LandsatDataCopier();
        }

        public async Task BuildLandsatDataCatalog()
        {
            // await _landsatCatalogBuilder.BuildCatalog("sa");
            await _landsatCatalogBuilder.BuildCatalog(
                new List<string>() { "oli-tirs" },
                new List<string>() { "2019", "2020", "2021" },
                new List<string>() { "144"},
                new List<string>() { "052" }

            );
        }
        
        public async Task CopyLandDataSets()
        {
            var fileName = "/Users/rajanp/dataproducts.json";
            
            List<string> filters = new List<string>()
            {
                "coastal", "blue", "green", "red", "nir08", "swir16", "swir22"
            };

            await _landsatDataCopier.CopyDataSets(fileName, filters);
        }
    }
}
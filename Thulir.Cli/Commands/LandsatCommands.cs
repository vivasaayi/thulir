using System.Collections.Generic;
using System.Threading.Tasks;
using Thulir.Landsat.Services;
namespace Thulir.Cli.Commands
{
    public class LandsatCommands
    {
        private ILandsatCatalogBuilder _landsatCatalogBuilder;
        
        public LandsatCommands()
        {
            _landsatCatalogBuilder = new LandsatCatalogBuilder();
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
        
        public void CopyLandSatFile()
        {
            
        }
    }
}
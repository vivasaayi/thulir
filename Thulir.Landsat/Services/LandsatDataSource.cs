using System.Threading.Tasks;
using Thulir.Landsat.Models;
using Thulir.Landsat.Repositories;

namespace Thulir.Landsat.Services
{
    public class LandsatDataSource : ILandsatDataSource
    {
        private IAwsDataInterface _awsDataInterface;
        
        public LandsatDataSource()
        {
            _awsDataInterface = new AwsDataInterface();
        }
        public async Task<LandsatCatalog> ListCatalog(string key)
        {
            var catalog = await _awsDataInterface.ListC2L2DataCatalog(key);
            return catalog;
        }
    }
}
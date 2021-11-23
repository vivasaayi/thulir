using System.Threading.Tasks;
using Thulir.Landsat.Models;

namespace Thulir.Landsat.Repositories
{
    public interface IAwsDataInterface
    {
        public Task<LandsatCatalog> ListC2L2DataCatalog(string keyName);
        public Task<LandsatCatalog> ListC2L2DataCatalog(string year, string path, string row);
        public void DownloadC2L2DataSets(string path);
    }
}
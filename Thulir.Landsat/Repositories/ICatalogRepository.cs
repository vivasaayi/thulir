using System.Threading.Tasks;
using Thulir.Landsat.Models;

namespace Thulir.Landsat.Repositories
{
    public interface ICatalogRepository
    {
        public Task SaveCatalog(LandsatCatalog catalog);
        public Task<LandsatCatalog> GetCatalog(string keyName);
    }
}
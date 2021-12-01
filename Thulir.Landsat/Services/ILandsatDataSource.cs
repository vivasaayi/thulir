using System.Threading.Tasks;
using Thulir.Landsat.Models;

namespace Thulir.Landsat.Services
{
    public interface ILandsatDataSource
    {
        public Task<LandsatCatalog> ListCatalog(string key);
    }
}
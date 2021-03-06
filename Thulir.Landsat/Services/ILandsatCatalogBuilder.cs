using System.Collections.Generic;
using System.Threading.Tasks;
using Thulir.Landsat.Models;

namespace Thulir.Landsat.Services
{
    public interface ILandsatCatalogBuilder
    {
        public Task<LandsatCatalog>  BuildCatalog(List<string>  instruments,  List<string>  years,  List<string>  paths, List<string>  rows);
        public Task<LandsatCatalog>  GetIndexedCatalog();
        public Task<List<string>> GetFiles();
    }
}
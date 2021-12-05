using System.Collections.Generic;
using System.Threading.Tasks;

namespace Thulir.Landsat.Services
{
    public interface ILandsatDataCopier
    {
        public Task CopyDataSets(string fileName, List<string> filters);
        public Task<List<string>> SyncS3Files();

        public Task SyncS3FolderToLocal(string keyName, string directory);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.S3.Model;

namespace Thulir.Landsat.Repositories
{
    public interface IS3DataSets
    {
        public Task<List<string>> GetFiles();

        public Task<string> CopyFile(string sourceObjectKey, string destinationObjectKey);
    }
}
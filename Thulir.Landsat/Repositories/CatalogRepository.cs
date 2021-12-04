using System;
using System.Text.Json;
using System.Threading.Tasks;
using Thulir.Aws;
using Amazon;
using Amazon.S3;
using Thulir.Landsat.Models;

namespace Thulir.Landsat.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private S3Client _s3Client;
        private string _bucketName = "thulir-datastore";
        private static readonly RegionEndpoint _bucketRegion = RegionEndpoint.USWest2;

        public CatalogRepository()
        {
            _s3Client = new S3Client(_bucketRegion);
        }

        public async Task SaveCatalog(LandsatCatalog catalog)
        {
            Console.WriteLine("Saving Landsat Catalog: " + catalog.Description);
            string data  = JsonSerializer.Serialize(catalog);
            await _s3Client.SaveFileContent(_bucketName, catalog.Description, RequestPayer.Requester, "application/json", data);
        }

        public async Task<LandsatCatalog> GetCatalog(string keyName)
        {
            var content =  await _s3Client.GetFileContent(_bucketName, keyName, RequestPayer.Requester);

            return JsonSerializer.Deserialize<LandsatCatalog>(content);
        }
    }
}
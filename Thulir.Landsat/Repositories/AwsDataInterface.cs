using System;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Thulir.Aws;
using Thulir.Landsat.Models;

namespace Thulir.Landsat.Repositories
{
    public class AwsDataInterface : IAwsDataInterface
    {
        private S3Client _s3Client;
        private string _bucketName = "usgs-landsat";
        private static readonly RegionEndpoint _bucketRegion = RegionEndpoint.USWest2;
        public AwsDataInterface()
        {
            _s3Client = new S3Client(_bucketRegion);
        }

        private void ParseCatalog(string data)
        {
            
        }

        public async Task<LandsatCatalog> ListC2L2DataCatalog(string keyName)
        {
            Console.WriteLine("Getting the catalog for base path: " + keyName);
            var data  = await _s3Client.GetFileContent(_bucketName, keyName, RequestPayer.Requester);
            Console.Write(data);
            
            LandsatCatalog landsatCatalog = 
                JsonSerializer.Deserialize<LandsatCatalog>(data);

            Console.WriteLine($"Total no of links: {landsatCatalog.Links.Length}");

            return landsatCatalog;
        }

        public async Task<LandsatCatalog> ListC2L2DataCatalog(string year, string path, string row)
        {
            // aws s3 cp s3://usgs-landsat/collection02/level-2/standard/oli-tirs/2021/144/052/catalog.json . --request-payer requester --request-payer requester
            Console.WriteLine("Getting L2 DataSets for ", path, row);

            var keyName = string.Format("collection02/level-2/standard/oli-tirs/{0}/{1}/{2}/catalog.json", year, path, row);
            var data  = await _s3Client.GetFileContent(_bucketName, keyName, RequestPayer.Requester);
            
            Console.Write(data);

            return null;
        }

        public void DownloadC2L2DataSets(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Thulir.Aws;
using Thulir.Landsat.Models;

namespace Thulir.Landsat.Repositories
{
    public class S3DataSets : IS3DataSets
    {
        private S3Client _s3Client;
        private string _bucketName = "landsat-dataasets";
        private string _landsatBucketName = "usgs-landsat";
        private static readonly RegionEndpoint _bucketRegion = RegionEndpoint.USWest2;

        public S3DataSets()
        {
            _s3Client = new S3Client(_bucketRegion);
        }


        public async Task<List<string>> GetFiles()
        {
            var files = await _s3Client.GetFileNames(_bucketName, RequestPayer.Requester);
            var result = files.Select(s => s.Key).ToList();
            return result;
        }

        public async Task<string> CopyFile(string sourceObjectKey, string destinationObjectKey)
        {
            var result = await _s3Client.CopyObject(_landsatBucketName, sourceObjectKey, _bucketName, destinationObjectKey,
                RequestPayer.Requester);
            return result;
        }

        public async Task SyncS3DirectoryToLocal(string keyName, string directory)
        {
            await _s3Client.SyncS3ToLocal(_bucketName, keyName, directory);
        }
    }
}
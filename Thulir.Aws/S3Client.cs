using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace Thulir.Aws
{
    public class S3Client
    {
        private static IAmazonS3 client;

        public S3Client(RegionEndpoint bucketRegion)
        {
            client = new AmazonS3Client(bucketRegion);
        }

        public async Task<string> GetFileContent(string bucketName, string keyName, RequestPayer requestPayer)
        {
            string responseBody = "";
            try
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName,
                    RequestPayer = requestPayer
                };
                using (GetObjectResponse response = await client.GetObjectAsync(request))
                using (Stream responseStream = response.ResponseStream)
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    string title =
                        response.Metadata["x-amz-meta-title"]; // Assume you have "title" as medata added to the object.
                    string contentType = response.Headers["Content-Type"];
                    Console.WriteLine("Object metadata, Title: {0}", title);
                    Console.WriteLine("Content type: {0}", contentType);

                    responseBody = reader.ReadToEnd(); // Now you process the response body.
                }
            }
            catch (AmazonS3Exception e)
            {
                // If bucket or object does not exist
                Console.WriteLine("Error encountered ***. Message:'{0}' when reading object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when reading object", e.Message);
            }

            return responseBody;
        }

        public async Task SaveFileContent(string bucketName, string keyName, RequestPayer requestPayer,
            string contentType, string data)
        {
            try
            {
                PutObjectRequest request = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName,
                    RequestPayer = requestPayer,
                    ContentBody = data,
                    ContentType = contentType
                };

                await client.PutObjectAsync(request);
            }
            catch (AmazonS3Exception e)
            {
                // If bucket or object does not exist
                Console.WriteLine("Error encountered ***. Message:'{0}' when reading object", e.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when reading object", e.Message);
                throw;
            }
        }

        public async Task<List<S3Object>> GetFileNames(string bucketName, RequestPayer requestPayer)
        {
            try
            {
                ListObjectsV2Request request = new ListObjectsV2Request()
                {
                    BucketName = bucketName,
                    RequestPayer = requestPayer
                };

                var response = await client.ListObjectsV2Async(request);

                return response.S3Objects;
            }
            catch (AmazonS3Exception e)
            {
                // If bucket or object does not exist
                Console.WriteLine("Error encountered ***. Message:'{0}' when reading object", e.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when reading object", e.Message);
                throw;
            }
        }

        public async Task<string> CopyObject(string sourceBucket, string sourceObjectKey, string destinationBucket,
            string destObjectKey, RequestPayer requestPayer)
        {
            try
            {
                CopyObjectRequest request = new CopyObjectRequest
                {
                    SourceBucket = sourceBucket,
                    SourceKey = sourceObjectKey,
                    DestinationBucket = destinationBucket,
                    DestinationKey = destObjectKey,
                    RequestPayer = requestPayer
                };
                CopyObjectResponse response = await client.CopyObjectAsync(request);
                return response.LastModified;
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }

            return "";
        }
    }
}
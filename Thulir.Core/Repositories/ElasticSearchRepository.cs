using System;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;

namespace Thulir.Core.Repositories
{
    public class ElasticSearchRepository
    {
        // private AwsHttpConnection httpConnection;
        private SingleNodeConnectionPool pool;
        private ConnectionSettings config;
        private ElasticClient client;
        private string indexName;
        private string esUrl;

        public ElasticSearchRepository(string indexName, string url)
        {
            this.indexName = indexName;
            this.esUrl = url;
            
            InitClient();
        }
        
        public void InitClient()
        {
            if (client != null)
            {
                return;
            }
            
            
                
            // httpConnection = new AwsHttpConnection("us-west-2");
            pool = new SingleNodeConnectionPool(new Uri(this.esUrl));
            config = new ConnectionSettings(pool)
                .DefaultIndex(this.indexName);
            
            client = new ElasticClient(config);
        }
        public async Task<string> ListIndices()
        {
            var indicesResponse = await client.Cat.IndicesAsync();

            if (indicesResponse.ApiCall.Success)
            {
                return indicesResponse.Records.ToString();
            }
            
            return "";
        }

        public async Task<string> SaveDoc(Object data)
        {
            var indexResponse = await client.IndexAsync(data, i => i.Index(this.indexName));
            
            if (indexResponse.ApiCall.Success)
            {
                return indexResponse.Id;
            }

            Console.WriteLine("Unable to save document to Elastic Search");
            Console.WriteLine(indexResponse.ApiCall.HttpStatusCode);
            Console.WriteLine(indexResponse.ApiCall.OriginalException);
            Console.WriteLine(indexResponse.ApiCall.DebugInformation);
            Console.WriteLine(indexResponse.OriginalException);
            Console.WriteLine(indexResponse.ServerError);
            Console.WriteLine(indexResponse.Result);
            Console.WriteLine(indexResponse);

            return "";
        }
    }
}
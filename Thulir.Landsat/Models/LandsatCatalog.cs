using System.Net.NetworkInformation;
using System.Text.Json.Serialization;

namespace Thulir.Landsat.Models
{
    public class LandsatCatalogItem
    {
        [JsonPropertyName("rel")]
        public string Rel { get; set; }
        
        [JsonPropertyName("href")]
        public string Href { get; set; }
        
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
    
    public class LandsatCatalog
    {
        [JsonPropertyName("stac_version")]
        public  string StacVersion { get; set; }
        
        [JsonPropertyName("id")]
        public  string Id { get; set; }
        
        [JsonPropertyName("description")]
        public  string Description { get; set; }

        [JsonPropertyName("links")]
        // public List<LandsatCatalogItem> Links { get; set; }
        public LandsatCatalogItem[] Links { get; set; }

    }
}
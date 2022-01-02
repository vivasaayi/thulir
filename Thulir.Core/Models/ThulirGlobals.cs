using System.Text.Json.Serialization;

namespace Thulir.Core.Models
{
    public class ThulirGlobals
    {
        [JsonPropertyName("openWeatherAppKey")]
        public string OpenWeatherAppKey { get; set; }
        
        [JsonPropertyName("elasticsearchurl")]
        public string ElasticSearchUrl { get; set; }
    }
}
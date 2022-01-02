using System.Text.Json.Serialization;

namespace Thulir.Weather.Models.OpenWeather
{
    public class OWTempForecast
    {
        [JsonPropertyName("day")]
        public double Day { get; set; }
        
        [JsonPropertyName("night")]
        public double Night { get; set; }
        
        [JsonPropertyName("min")]
        public double Min { get; set; }
        
        [JsonPropertyName("max")]
        public double Max { get; set; }
        
        [JsonPropertyName("eve")]
        public double Evening { get; set; }
        
        [JsonPropertyName("morn")]
        public double Morning { get; set; }
    }
}
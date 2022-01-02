using System.Text.Json;
using System.Text.Json.Serialization;

namespace Thulir.Weather.Models.OpenWeather
{
    public class OneCallAPIResponse
    {
        [JsonPropertyName("lat")]
        public double Lattitude { get; set; }
        
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
        
        [JsonPropertyName("timezone")]
        public string TimeZone { get; set; }
        
        [JsonPropertyName("timezone_offset")]
        public int TimeZoneOffset { get; set; }
        
        [JsonPropertyName("current")]
        public OpenWeatherInfo Current { get; set; }
        
        [JsonPropertyName("hourly")]
        public OpenWeatherInfo[] Hourly { get; set; }
        
        [JsonPropertyName("daily")]
        public OWDailyWeatherInfo[] Daily { get; set; }
        
        [JsonPropertyName("minutely")]
        public  OpenWeatherMinutelyForecast[] Minutely { get; set; }
    }
}
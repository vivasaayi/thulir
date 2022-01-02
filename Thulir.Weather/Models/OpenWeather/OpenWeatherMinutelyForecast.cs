using System.Text.Json.Serialization;

namespace Thulir.Weather.Models.OpenWeather
{
    public class OpenWeatherMinutelyForecast
    {
        [JsonPropertyName("dt")]
        public double TimeStamp { get; set; }
        
        [JsonPropertyName("precipitation")]
        public double Precipitation { get; set; }
    }
}
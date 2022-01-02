using System.Text.Json.Serialization;
using Thulir.Weather.Models.OpenWeather;

namespace Thulir.Weather.Models
{
    public class OWCurrentWeatherInfo : OWBaseWeatherInfo
    {
        [JsonPropertyName("temp")]
        public double Temperature  { get; set; }
        
        [JsonPropertyName("feels_like")]
        public double FeelsLike  { get; set; }

    }
}
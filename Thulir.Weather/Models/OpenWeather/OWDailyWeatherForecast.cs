using System.Text.Json.Serialization;

namespace Thulir.Weather.Models.OpenWeather
{
    public class OWDailyWeatherForecast : OWBaseWeatherInfo
    {
        [JsonPropertyName("temp")]
        public OWTempForecast Temperature  { get; set; }
        
        [JsonPropertyName("feels_like")]
        public OWTempForecast FeelsLike  { get; set; }
    }
}
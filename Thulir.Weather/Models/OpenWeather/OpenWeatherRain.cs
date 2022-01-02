using System.Text.Json.Serialization;

namespace Thulir.Weather.Models.OpenWeather
{
    public class OpenWeatherRain
    {
        [JsonPropertyName("1h")]
        public double OneH { get; set; }
    }
}
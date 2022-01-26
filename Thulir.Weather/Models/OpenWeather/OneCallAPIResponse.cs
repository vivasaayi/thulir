using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Thulir.Weather.Models.OpenWeather
{
    public class OneCallAPIResponse
    {
        [JsonPropertyName("cityid")]
        public string CityId { get; set; }
        
        [JsonPropertyName("lat")]
        public double Lattitude { get; set; }
        
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
        
        [JsonPropertyName("timezone")]
        public string TimeZone { get; set; }
        
        [JsonPropertyName("timezone_offset")]
        public int TimeZoneOffset { get; set; }
        
        [JsonPropertyName("current")]
        public OWCurrentWeatherInfo Current { get; set; }
        
        [JsonPropertyName("hourly")]
        public OWCurrentWeatherInfo[] Hourly { get; set; }
        
        [JsonPropertyName("daily")]
        public OWDailyWeatherForecast[] Daily { get; set; }
        
        [JsonPropertyName("minutely")]
        public  OWMinutelyForecast[] Minutely { get; set; }

        [JsonPropertyName("@timestamp")]
        public double TimeStamp { get; set; }
        
    }
}
using System.Text.Json.Serialization;

namespace Thulir.Weather.Models.OpenWeather
{
    public class OWBaseWeatherInfo
    {
        [JsonPropertyName("dt")]
        public double TimeStamp { get; set; }
        
        [JsonPropertyName("temp_min")]
        public double TempMin  { get; set; }
        
        [JsonPropertyName("temp_max")]
        public double TempMax  { get; set; }
        
        [JsonPropertyName("pressure")]
        public double Pressure  { get; set; }
        
        [JsonPropertyName("humidity")]
        public double Humidity  { get; set; }
        
        [JsonPropertyName("dew_point")]
        public double DewPoint  { get; set; }
        
        [JsonPropertyName("sea_level")]
        public double SeaLevel  { get; set; }
        
        [JsonPropertyName("ground_level")]
        public double GroundLevel { get; set; }
        
        [JsonPropertyName("visibility")]
        public int Visibility  { get; set; }

        [JsonPropertyName("wind_speed")]
        public double WindSpeed  { get; set; }
        
        [JsonPropertyName("wind_deg")]
        public double WindDegree { get; set; }
        
        [JsonPropertyName("wind_gust")]
        public double WindGust  { get; set; }

        [JsonPropertyName("sunrise")]
        public double Sunrise  { get; set; }
        
        [JsonPropertyName("sunset")]
        public double Sunset  { get; set; }

        [JsonPropertyName("uvi")]
        public double UVI  { get; set; }
        
        [JsonPropertyName("clouds")]
        public double Clouds { get; set; }

        [JsonPropertyName("pop")]
        public double Pop  { get; set; }

        [JsonPropertyName("weather")]
        public OpenWeatherCondition[] Weather { get; set; }
        
        public OpenWeatherRain Rain { get; set; }
        
        public OpenWeatherSnow Snow { get; set; }
    }
}
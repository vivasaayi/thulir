using System.Text.Json.Serialization;
using Thulir.Weather.Models.OpenWeather;

namespace Thulir.Weather.Models.DB
{
    public class LatestWeather
    {
        public string City { get; set; }
        public OWCurrentWeatherInfo CurrentWeather { get; set; }
        public OWDailyWeatherForecast[] Forecast { get;set; }
        public OneCallAPIResponse Raw { get; set; }
    }
}
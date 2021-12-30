using System.Collections.Generic;
using System.Threading.Tasks;
using Thulir.Weather.Models;

namespace Thulir.Weather.Services
{
    public class WeatherService: IWeatherService
    {
        public async Task<WeatherInfo[]> GetWeatherData()
        {
            var result = new List<WeatherInfo>();

            result.Add(new WeatherInfo());
            result.Add(new WeatherInfo());
            result.Add(new WeatherInfo());
            
            
            return result.ToArray();
        }

        public void GetWeatherAlerts()
        {
            throw new System.NotImplementedException();
        }
    }
}
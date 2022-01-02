using System.Collections.Generic;
using System.Threading.Tasks;
using Thulir.Weather.Models;

namespace Thulir.Weather.Services
{
    public class WeatherService: IWeatherService
    {
        public async Task<OpenWeatherInfo> GetWeatherData()
        {
            return new OpenWeatherInfo();
        }

        public void GetWeatherAlerts()
        {
            throw new System.NotImplementedException();
        }
    }
}
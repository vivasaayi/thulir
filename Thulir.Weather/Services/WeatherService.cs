using System.Collections.Generic;
using System.Threading.Tasks;
using Thulir.Core.Dals;
using Thulir.Weather.Models;
using Thulir.Weather.Models.DB;
using Thulir.Weather.Repositories;

namespace Thulir.Weather.Services
{
    public class WeatherService: IWeatherService
    {
        private IWeatherRepository _weatherRepository;
        
        public WeatherService()
        {
            _weatherRepository = new WeatherRepository(PostgresDal.GetInstance());
        }
        public async Task<LatestWeather> GetWeatherData(string city)
        {
            var result = await _weatherRepository.GetCurrentWeather(city);
            return result;
        }

        public void GetWeatherAlerts()
        {
            throw new System.NotImplementedException();
        }
    }
}
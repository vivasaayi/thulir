using System.Threading.Tasks;
using Thulir.Weather.Models;
using Thulir.Weather.Models.DB;

namespace Thulir.Weather.Services
{
    public interface IWeatherService
    {
        public Task<LatestWeather> GetWeatherData(string city);
        public void GetWeatherAlerts();
    }
}
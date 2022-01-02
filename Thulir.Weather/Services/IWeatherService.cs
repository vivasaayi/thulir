using System.Threading.Tasks;
using Thulir.Weather.Models;

namespace Thulir.Weather.Services
{
    public interface IWeatherService
    {
        public Task<OpenWeatherInfo> GetWeatherData();
        public void GetWeatherAlerts();
    }
}
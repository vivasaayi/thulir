using System.Threading.Tasks;
using Thulir.Weather.Models;

namespace Thulir.Weather.Services
{
    public interface IWeatherService
    {
        public Task<OWCurrentWeatherInfo> GetWeatherData();
        public void GetWeatherAlerts();
    }
}
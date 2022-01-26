using System.Threading.Tasks;
using Thulir.Weather.Models.OpenWeather;

namespace Thulir.Weather.Repositories
{
    public interface IWeatherRepository
    {
        public Task SaveCurrentWeather(OneCallAPIResponse oneCallApiResponse);
        public Task<OneCallAPIResponse> GetCurrentWeather(string city);
    }
}
using System.Threading.Tasks;
using Thulir.Weather.Models.DB;
using Thulir.Weather.Models.OpenWeather;

namespace Thulir.Weather.Repositories
{
    public interface IWeatherRepository
    {
        public Task SaveCurrentWeather(OneCallAPIResponse oneCallApiResponse);
        public Task<LatestWeather> GetCurrentWeather(string city);
    }
}
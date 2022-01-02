using System.Threading.Tasks;
using Thulir.Weather.Models;

namespace Thulir.Weather.Proxies
{
    public interface IWeatherSourceProxy
    {
        public Task<OpenWeatherInfo> GetWeatherInfo();
    }
}
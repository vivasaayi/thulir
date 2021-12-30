using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thulir.Landsat.Models;
using Thulir.Landsat.Services;
using Thulir.Weather.Models;
using Thulir.Weather.Services;

namespace Thulir.ReactUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {

        private IWeatherService _weatherService = new WeatherService();
        
        [HttpGet("current-weather")]
        public async Task<WeatherInfo[]> GetCurrentWeather(string? location)
        {
            if (string.IsNullOrEmpty(location))
            {
                location = "";
            }

            var result = await _weatherService.GetWeatherData();
            return result;
        }
    }
    
}
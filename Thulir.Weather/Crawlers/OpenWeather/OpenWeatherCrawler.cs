using System;
using System.Threading.Tasks;
using Nest;
using Thulir.Aws;
using Thulir.Core.Dals;
using Thulir.Core.Models;
using Thulir.Core.Repositories;
using Thulir.Core.Services;
using Thulir.Weather.Models.OpenWeather;
using Thulir.Weather.Proxies;
using Thulir.Weather.Repositories;

namespace Thulir.Weather.Crawler.crawlers
{
    public class OpenWeatherCrawler : IWeatherCrawler
    {
        private OpenWeatherProxy _proxy = new OpenWeatherProxy();
        private IWeatherRepository _weatherRepository;

        public OpenWeatherCrawler()
        {
            _weatherRepository = new WeatherRepository(PostgresDal.GetInstance());
        }

        public async Task CrawlLocation(double lattitude, double longitude, string locationId)
        {
            OneCallAPIResponse result =  await _proxy.MakeOneCallApi(lattitude, longitude);
            result.CityId = locationId;
            result.TimeStamp = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds;
            await _weatherRepository.SaveCurrentWeather(result);
        }
        
        public async Task Crawl()
        {
            Console.WriteLine("Crawling OpenWeather Endpoints");

            var cities = OpenWeatherConstants.OpenWeatherCities;

            foreach (var city in cities)
            {
                System.Console.WriteLine(city);
                await CrawlLocation(city.Lattitude, city.Longitude, city.Name);
            }
            
            Console.WriteLine("Completed Crawling OpenWeather Endpoints");
        }
    }
}
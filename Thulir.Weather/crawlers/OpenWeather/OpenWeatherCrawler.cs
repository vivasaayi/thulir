using System;
using System.Threading.Tasks;
using Thulir.Aws;
using Thulir.Core.Services;
using Thulir.Weather.Proxies;

namespace Thulir.Weather.Crawler.crawlers
{
    public class OpenWeatherCrawler : IWeatherCrawler
    {
        private OpenWeatherProxy _proxy = new OpenWeatherProxy();

        
        public async Task CrawlLocation(double lattitude, double longitude, string locationId)
        {
            var result =  await _proxy.MakeOneCallApi(lattitude, longitude);
        }
        
        public async Task Crawl()
        {
            Console.WriteLine("Crawling OpenWeather Endpoints");

            var cities = OpenWeatherConstants.OpenWeatherCities;

            foreach (var city in cities)
            {
                await CrawlLocation(city.Lattitude, city.Longitude, city.Name);
            }
            
            Console.WriteLine("Completed Crawling OpenWeather Endpoints");
        }
    }
}
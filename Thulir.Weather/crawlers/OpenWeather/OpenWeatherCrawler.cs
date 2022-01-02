using System;
using System.Threading.Tasks;

namespace Thulir.Weather.Crawler.crawlers
{
    public class OpenWeatherCrawler : IWeatherCrawler
    {
        public async Task CrawlLocation(double lattitude, double longitude, string locationId)
        {
            
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
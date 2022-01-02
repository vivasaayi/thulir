using System;
using System.Threading.Tasks;
using Nest;
using Thulir.Aws;
using Thulir.Core.Models;
using Thulir.Core.Repositories;
using Thulir.Core.Services;
using Thulir.Weather.Models.OpenWeather;
using Thulir.Weather.Proxies;

namespace Thulir.Weather.Crawler.crawlers
{
    public class OpenWeatherCrawler : IWeatherCrawler
    {
        private OpenWeatherProxy _proxy = new OpenWeatherProxy();
        ElasticSearchRepository _elasticSearchRepository;
        private ThulirSecrets _secrets = new ThulirSecrets();
        

        private async Task InitElasticSearchRepo()
        {
            if (_elasticSearchRepository != null)
            {
                return;    
            }
            ThulirGlobals globals = await _secrets.GetThulirGlobals();
            _elasticSearchRepository = new ElasticSearchRepository("weather", globals.ElasticSearchUrl);
        }
        
        public async Task CrawlLocation(double lattitude, double longitude, string locationId)
        {
            OneCallAPIResponse result =  await _proxy.MakeOneCallApi(lattitude, longitude);
            result.CityId = locationId;
            await _elasticSearchRepository.SaveDoc(result);
        }
        
        public async Task Crawl()
        {
            InitElasticSearchRepo();
            Console.WriteLine("Crawling OpenWeather Endpoints");

            await _elasticSearchRepository.ListIndices();

            var cities = OpenWeatherConstants.OpenWeatherCities;

            foreach (var city in cities)
            {
                await CrawlLocation(city.Lattitude, city.Longitude, city.Name);
            }
            
            Console.WriteLine("Completed Crawling OpenWeather Endpoints");
        }
    }
}
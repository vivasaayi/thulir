using System.Threading.Tasks;

namespace Thulir.Weather.Crawler.crawlers
{
    public interface IWeatherCrawler
    {
        public Task Crawl();
    }
}
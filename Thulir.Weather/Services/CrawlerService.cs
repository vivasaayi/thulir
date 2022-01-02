using System;
using System.Collections.Generic;
using System.Threading;
using Thulir.Weather.Crawler.crawlers;

namespace Thulir.Weather.Crawler.Services
{
    public class CrawlerService
    {
        private List<IWeatherCrawler> crawlers = new List<IWeatherCrawler>();
        private int intervalInMinutes = 10;

        public void Init()
        {
            crawlers.Add(new OpenWeatherCrawler());
        }
        
        public async void Start()
        {
            while (true)
            {
                Console.WriteLine("Started Crawling..");
                foreach (var crawler in crawlers)
                {
                    await crawler.Crawl();   
                }
                Console.WriteLine("Completed Crawling..");
                Thread.Sleep(intervalInMinutes * 60 * 1000);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Thulir.News.Services
{
    public class NewsService : INewsService
    {
        public async Task<Models.News[]> GetNews()
        {
            var result = new List<Models.News>();

            result.Add(new Models.News()
            {
                Message = "AAA",
                Title = "AAA",
                TimeStamp = new DateTime()
            });
            result.Add(new Models.News()
            {
                Message = "BBB",
                Title = "BBB",
                TimeStamp = new DateTime()
            });

            result.Add(new Models.News()
            {
                Message = "CCC",
                Title = "CCC",
                TimeStamp = new DateTime()
            });
            
            result.Add(new Models.News()
            {
                Message = "CCC",
                Title = "CCC",
                TimeStamp = new DateTime()
            });

            return result.ToArray();
        }
    }
}
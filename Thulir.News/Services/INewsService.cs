using System.Collections;
using System.Threading.Tasks;

namespace Thulir.News.Services
{
    public interface INewsService
    {
        public Task<Models.News[]> GetNews();
    }
}
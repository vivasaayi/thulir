using Microsoft.AspNetCore.Mvc;

namespace Thulir.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        public string Index()
        {
            return "Hello";
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace MagicShop.Controllers
{
    [Route("test")]
    public class TestController : Controller
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MagicShop.Controllers
{
    [Route("search")]
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpPost]
        public  async Task<IActionResult> Index(string request)
        {
            var search = await _searchService.Search(request);
            return View(search);
        }
    }
}

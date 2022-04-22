using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<MovieDBAuth> _config;

        public HomeController(IOptions<MovieDBAuth> config)
        {
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchResults()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SearchResults(SearchQuery searchQuery)
        {
            string? token = _config.Value.Token;
            MovieDbFactory.RegisterSettings(token);
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            ApiSearchResponse<MovieInfo> response = await movieApi.SearchByTitleAsync(searchQuery.Query);
            IReadOnlyList<MovieInfo> responseData = response.Results;
            ViewBag.Response = responseData;
            return View();
        }
    }
}
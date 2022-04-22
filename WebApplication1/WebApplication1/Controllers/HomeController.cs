using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

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
            string token = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI1YTZmNmZhZmRhMDc2ODkyOWNkMTI5Yzc0NDU4OWY2ZiIsInN1YiI6IjYxZWQ1ZWMwMDA2YjAxMDBjZWUwOTkzYyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.Chtv2Z0jCYgml5Un3ezHwikE5CNigcxqvK2S5ogjyDs";
            MovieDbFactory.RegisterSettings(token);
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            ApiSearchResponse<MovieInfo> response = await movieApi.SearchByTitleAsync(searchQuery.Query);
            IReadOnlyList<MovieInfo> responseData = response.Results;
            ViewBag.Response = responseData;
            return View();
        }
    }
}
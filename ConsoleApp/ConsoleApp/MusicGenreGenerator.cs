using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class MusicGenreGenerator
    {
        private readonly HttpClient _httpClient;

        public MusicGenreGenerator(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GenerateNewGenre(CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync("https://binaryjazz.us/wp-json/genrenator/v1/genre/", cancellationToken);
            var strResult = await response.Content.ReadAsStringAsync(cancellationToken);
            return strResult;
        }
    }
}

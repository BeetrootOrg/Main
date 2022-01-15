using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class FoodClient
    {
        private readonly HttpClient _httpClient;

        public FoodClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ImageResult> GetRandomImage(CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync("https://foodish-api.herokuapp.com/api", cancellationToken);
            var strResult = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonConvert.DeserializeObject<ImageResult>(strResult);
        }

        public async Task<byte[]> GetImage(ImageResult imageResult, CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync(imageResult.Image, cancellationToken);
            return await response.Content.ReadAsByteArrayAsync(cancellationToken);
        }
    }
}

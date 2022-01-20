using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class ActivityClient
    {
        private readonly HttpClient _httpClient;

        public ActivityClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ActivityResult> GetRandomActivity(CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync("https://www.boredapi.com/api/activity", cancellationToken);
            var strResult = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonConvert.DeserializeObject<ActivityResult>(strResult);
        }
    }
}

using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace ConsoleApp
{
    internal class FactClient
    {
        private readonly HttpClient _httpClient;

        public FactClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CatFact> GetRandomFact(CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync("https://cat-fact.herokuapp.com/facts/random", cancellationToken);
            var strResult = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonConvert.DeserializeObject<CatFact>(strResult);
        }

        public  string GetFact(CatFact catFact)
        {

            var fact  = catFact.Text;
            return fact;

        }
    }
}

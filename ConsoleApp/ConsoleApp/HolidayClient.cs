using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleApp
{
    internal class HolidayClient
    {
        private readonly HttpClient _httpClient;

        public HolidayClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<object> GetHolidays(CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync("https://canada-holidays.ca/api/v1/holidays", cancellationToken);

            var strResult = await response.Content.ReadAsStringAsync(cancellationToken);

            var jsonobj = JsonConvert.DeserializeObject<Rootobject>(strResult);

            return jsonobj;
        }


    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class WeatherClient
    {
        private readonly HttpClient _httpClient;

        public WeatherClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherHttpResult> GetForecast(CancellationToken cancelletionTokken = default)
        {
            using var response = await _httpClient.GetAsync($"https://www.metaweather.com/api/location/924938/{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.AddDays(1).Day}/");
            var strResult = await response.Content.ReadAsStringAsync(cancelletionTokken);
            return JsonConvert.DeserializeObject<List<WeatherHttpResult>>(strResult)[0];
        }

    }
}

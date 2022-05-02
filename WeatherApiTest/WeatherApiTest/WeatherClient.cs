using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WeatherApiTest;

namespace ConsoleApp
{
    internal class WeatherClient
    {
        private readonly HttpClient _httpClient;

        public WeatherClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> GetForecast(CancellationToken cancelletionTokken = default)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };

            using var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q=London&appid=92a14d87197459ca657a1a1176d75dac&units=metric");
            var strResult = await response.Content.ReadAsStringAsync(cancelletionTokken);
            return JsonConvert.DeserializeObject<Response>(strResult, settings);
        }
    }
}
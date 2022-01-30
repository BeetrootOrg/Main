using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;
using System.Net.Http;
using ConsoleApp;
using System.Threading;
using System.Threading.Tasks;

namespace LinqLesson;

static class WeatherAPI
{

    class Program
    {
        static async Task Main()
        {
            using var httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(5),
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            var forecast = new WeatherClient(httpClient);

            Console.WriteLine("Please wait until random image will be generated...");
            var forecastResult = await forecast.GetForecast(cancellationToken);

            
            Console.WriteLine($"Weather in Kiev on {forecastResult.Applicable_date.Date}:");
            Console.WriteLine($"Max temp {forecastResult.Max_temp}");
            Console.WriteLine($"Min temp {forecastResult.Min_temp}");
            Console.WriteLine($"Wind speed {forecastResult.Wind_speed}");
            Console.WriteLine($"Predictability {forecastResult.Predictability}%");
            Console.Read();
        }
    }
}
using ConsoleApp;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;

namespace WeatherApiTest
{
    static class Program
    {
        public static void Main()
        {
            using var httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(5),
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            var forecast = new WeatherClient(httpClient);

            Console.WriteLine("Please wait until random image will be generated...");
            var forecastResult = forecast.GetForecast(cancellationToken);

            Console.WriteLine(forecastResult.Result.Visibility);
            Console.WriteLine(forecastResult.Result.Weather[0].Description);
            Console.WriteLine(forecastResult.Result.Main.Temp);
            Console.WriteLine("Feels like: " + forecastResult.Result.Main.FeelsLike);
            Console.WriteLine($"Weather in {forecastResult.Result.Name} is between {forecastResult.Result.Main.TempMin} and {forecastResult.Result.Main.TempMax}" +
                        $", current temp {forecastResult.Result.Main.Temp}");
        }
    }
}
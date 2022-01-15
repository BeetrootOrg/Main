using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
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

            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                cancellationTokenSource.Cancel();
            };

            var foodClient = new FoodClient(httpClient);

            var imageResult = await foodClient.GetRandomImage(cancellationToken);
            var image = await foodClient.GetImage(imageResult, cancellationToken);

            await File.WriteAllBytesAsync("image.jpg", image, cancellationToken);
        }
    }
}
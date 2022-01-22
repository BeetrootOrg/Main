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
                Timeout = TimeSpan.FromSeconds(15),
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                cancellationTokenSource.Cancel();
            };

            var foodClient = new FoodClient(httpClient);

            Console.WriteLine("Please wait until random image will be generated...");
            var imageResult = await foodClient.GetRandomImage(cancellationToken);
            //var image = await foodClient.GetImage(var, cancellationToken);


            Console.WriteLine(imageResult);
            //Console.WriteLine("Enter filename (skip if want to use random name):");
            //var filename = Console.ReadLine();

            //if (string.IsNullOrEmpty(filename))
            //{
            //    filename = $"{Guid.NewGuid()}.jpg";
            //}

            //await File.WriteAllBytesAsync(filename, image, cancellationToken);
            //Console.WriteLine($"Image saved to {filename}");
        }
    }
}
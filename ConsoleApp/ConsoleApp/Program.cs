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

            var factClient = new FactClient(httpClient);

            Console.WriteLine("Please wait while we getting a random fact...\n");
            var textResult = await factClient.GetRandomFact(cancellationToken);
            var fact = factClient.GetFact(textResult);

            Console.WriteLine($"Here is your random fact: {fact}");
            
        }
    }
}
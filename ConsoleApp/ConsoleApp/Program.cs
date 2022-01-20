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

            var activityClient = new ActivityClient(httpClient);

            Console.WriteLine("Please wait until random activity will be generated...");
            var activityResult = await activityClient.GetRandomActivity(cancellationToken);

            Console.WriteLine($"Activity - {activityResult.Activity}");
            Console.WriteLine($"Activity type - {activityResult.Type}");
            Console.WriteLine($"You need {(activityResult.Participants == 1 ? "only yourself" : $"{activityResult.Participants} people")}");

        }
    }
}

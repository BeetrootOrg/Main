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

            var generatedGenreClient = new MusicGenreGenerator(httpClient);

            Console.WriteLine("Please wait until new music genre will be generated...");
            var genreResult = await generatedGenreClient.GenerateNewGenre(cancellationToken);

            string value = $"You should try yourself in - {genreResult}";
            Console.WriteLine(value);
        }
    }
}
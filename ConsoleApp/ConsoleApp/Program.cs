using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
namespace ConsoleApp
{
    class Program
    {
        static async Task Main()
        {
            WriteLine("\r\n a.tkachenko/homework/23-asinc \r\n");
            WriteLine("This application shows the telemetry of the James Webb telescope");
            WriteLine("API reference: https://github.com/avatsaev/webb-tracker-api \r\n");

            using var httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(10),
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            CancelKeyPress += (sender, eventArgs) =>
            {
                cancellationTokenSource.Cancel();
            };

            var jameWebbClient = new JamesWebbClient(httpClient);

            WriteLine("Please wait until get data...");

            try
            {
                var imageResult = await jameWebbClient.GetData(cancellationToken);
                WriteLine("Enter filename (skip if want to use random name):");
                var filename = ReadLine();

                if (string.IsNullOrEmpty(filename))
                {
                    filename = $"{Guid.NewGuid()}.png";
                }

                await File.WriteAllBytesAsync(filename, imageResult, cancellationToken);
                WriteLine($"Image saved to {filename}");

                WriteLine("Please check data at \"https://www.jwst.nasa.gov/content/webbLaunch/whereIsWebb.html?units=metric\"");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            
        }
    }
}

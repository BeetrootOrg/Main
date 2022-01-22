using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{

 


    class Program
    {

        static string todayHoliday(Rootobject holidays)
        {
            holidays.Select(holiday => holiday.
            //var xxx = new IEnumerable < Rootobject > holidays; 
            var result = holidays
            
                .Select(x => x.)
                .First();

            return result.ToString();   
            Console.WriteLine($" {result} is the most populated company");

        }


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
            var holidayList = await foodClient.GetHolidays(cancellationToken);

            var resultX = todayHoliday((IEnumerable<Rootobject>)holidayList);



            Console.WriteLine($"Image saved to {todayHoliday}");
        }
    }
}
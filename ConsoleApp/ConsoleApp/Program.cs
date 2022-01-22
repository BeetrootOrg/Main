using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{

 


    class Program
    {

        static void todayHoliday(IEnumerable<Holiday> holidays)
        {
            var sb = new StringBuilder();


            DateTime currentDate = (DateTime.Now).Date;

            var resultNext = holidays
            .Where(x =>DateTime.Compare(currentDate, Convert.ToDateTime(x.date)) < 0)
                .Select(x=>new
                { 
                  x.date,
                  x.nameEn
                })
                .OrderBy(x => x.date) 
                .First();

            var resultPrevious = holidays
            .Where(x => DateTime.Compare(currentDate, Convert.ToDateTime(x.date)) > 0)
                .Select(x => new
                {
                    x.date,
                    x.nameEn
                })
                .OrderByDescending(x => x.date)
                .First();

            var resultCurrent = holidays
            .Where(x => DateTime.Compare(currentDate, Convert.ToDateTime(x.date)) == 0)
                .Select(x => new
                {
                    x.nameEn
                })
                .FirstOrDefault() ?? new { nameEn = "today is not a holiday" };


            sb.Append("Past Holiday: ");
            sb.Append(resultPrevious.nameEn);
            sb.Append(resultPrevious.date);
            sb.Append(",\n\n Current Holiday: ");
            sb.Append(resultCurrent);
            sb.Append(currentDate.ToString("yyyy-MM-dd"));
            sb.Append(",\n\n Forthcoming Holiday: ");
            sb.Append(resultNext.nameEn);
            sb.Append(resultNext.date);

            Console.WriteLine(sb.ToString()); 


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

            Console.WriteLine("What holiday is today in Canada? ");
            object holidayList = await foodClient.GetHolidays(cancellationToken);


            Holiday[] hl=((Rootobject)holidayList).holidays;  
          todayHoliday(hl);

        }
    }
}
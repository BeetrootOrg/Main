using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            DateTime date = new DateTime(1921, 10, 12, 15, 05, 10);
            Console.WriteLine(date);
            Console.WriteLine($"{date:f}");
            Console.WriteLine($"{date:yyyy-MM/dd}");

            DateTime now = DateTime.Now;
            Console.WriteLine(now);

            Console.WriteLine(now.Year);
            Console.WriteLine(date.Ticks);

            DateTime min = DateTime.MinValue;
            Console.WriteLine(min);

            Console.WriteLine(now > min);

            TimeSpan timeSpan = new TimeSpan(10, 12, 32, 56, 999);
            Console.WriteLine(timeSpan);

            TimeSpan diff = now - date;
            Console.WriteLine(diff);
            Console.WriteLine(diff.Days);
            Console.WriteLine(diff.Seconds);
            Console.WriteLine(diff.TotalSeconds);
            Console.WriteLine(diff.TotalMinutes);

            TimeSpan small = new TimeSpan(0, 0, 1);
            Console.WriteLine(small.TotalMinutes);

            // how to add something to datetitme
            // option 1 - call AddSMTHG()
            DateTime date1 = date.AddDays(5);
            Console.WriteLine(date);
            Console.WriteLine(date1);

            date1 = date.AddMonths(1).AddDays(-2).AddMinutes(5);
            Console.WriteLine(date1);
            Console.WriteLine(date1.AddMonths(1));

            // option 2 - with TimeSpan
            date1 = date1 + timeSpan;

            // option 3 - the same
            date1 = date1.Add(timeSpan);

            // subtract
            date1 = date1.Subtract(diff);
            Console.WriteLine(date1);

            // RANDOM
            Random rand = new Random((int)DateTime.Now.Ticks);
            Console.WriteLine(rand.Next());
            Console.WriteLine(rand.Next(10));
            Console.WriteLine(rand.Next(15, 20));

            Console.WriteLine(rand.NextDouble());
            Console.WriteLine(rand.NextSingle());
            Console.WriteLine(rand.NextInt64());
        }
    }
}
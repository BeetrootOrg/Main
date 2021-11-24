using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            DateTime date = new DateTime(2021, 10, 12, 15, 05, 10);
            Console.WriteLine(date);
            Console.WriteLine($"{date:f}");

            DateTime now = DateTime.Now;
            Console.WriteLine(now);
            Console.WriteLine(now.DayOfWeek);

            Console.WriteLine(date.Ticks);

            DateTime min = DateTime.MinValue;

            Console.WriteLine(now > min);

            TimeSpan timeSpan = new TimeSpan(10, 12, 32, 52, 999);

            Console.WriteLine(timeSpan);

            TimeSpan diff = now - date;
            Console.WriteLine(diff);
            Console.WriteLine(diff.Days);
            Console.WriteLine(diff.Seconds);
            Console.WriteLine(diff.TotalSeconds);

            //add something to datetime
            //1 -call AddSMTHNG
            DateTime date1 = date.AddDays(2);
            Console.WriteLine(date);
            Console.WriteLine(date1);

            date1 = date.AddMonths(1).AddDays(2).AddHours(4);
            Console.WriteLine(date1);

            //2 - with TimeSpan
            date1 = date1 + timeSpan;


            //3 - with TimeSpan
            date1 = date1.Add(timeSpan);

            //4 - substract
            date1 = date1.Subtract(diff);

            Console.WriteLine(date1);


            //Random
            Random rand = new Random((int)DateTime.Now.Ticks);

            Console.WriteLine(rand.Next());
            Console.WriteLine(rand.Next(5));
            Console.WriteLine(rand.Next(10, 48));
            Console.WriteLine(rand.NextDouble());
            Console.WriteLine(rand.NextSingle());
            Console.WriteLine(rand.NextInt64());

            Console.WriteLine("Start the game.");
            while (true)
            {
                Console.ReadLine();
                int random = rand.Next(0, 6);

                if (random == 0)
                {
                    Console.WriteLine("You Killed.");
                    break;
                }
                else
                {
                    Console.WriteLine($"You got {random}. Continue...");
                }
            }
        }


    }
}
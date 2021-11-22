using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            DateTime date = new DateTime(1921, 10, 12, 11, 23, 11);
            Console.WriteLine(date);

            DateTime now = DateTime.Now;


            DateTime min = DateTime.MinValue;
            Console.WriteLine($"now \n");
            Console.WriteLine(now > min);

            TimeSpan timeSpan = new TimeSpan(10, 12, 3, 12, 312);
            Console.WriteLine($"{ timeSpan}\n");

            TimeSpan diff = now - date;
            Console.WriteLine(diff);
            Console.WriteLine(diff.TotalDays);

            //how 2 add some time

            DateTime date1 = date.AddDays(5);
            Console.WriteLine(date);
            Console.WriteLine(date1);

            date1 = date.AddMonths(12).AddDays(12);

            Console.WriteLine(date1.AddMonths(3));

            //TimeSpan
            date1 = date1 + timeSpan;

            //the same
            date1 = date1.Add(timeSpan);

            //substract
            date1 = date1.Subtract(diff);
            Console.WriteLine(date1);

            //random

            Random rand = new Random((int)DateTime.Now.Ticks);
            Console.WriteLine(rand.Next());
            Console.WriteLine(rand.Next(10));
            Console.WriteLine(rand.Next(1,5));

            Console.WriteLine(rand.NextDouble());
            Console.WriteLine(rand.NextInt64());
            Console.WriteLine(rand.NextSingle());

            while (true)
            {
                Console.ReadLine();
                int random = rand.Next(0, 6);
                if (random == 0)
                {
                    Console.WriteLine("You killed");
                    break;
                }
                else
                {
                    Console.WriteLine($"You got {random}.Continue");
                }
            }
        }
    } 
}
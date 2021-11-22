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
            Console.WriteLine($"{date:yyyy-MM/dd}");

            DateTime now = DateTime.Now;
            Console.WriteLine(now);
        }
    }
}
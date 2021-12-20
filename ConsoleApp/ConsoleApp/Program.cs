using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
namespace ConsoleApp
{
    //i.safontev/classwork/17-timer

    class Program
    {
        static void Main()
        {
            /*
            var i = 5;
            var j = 2;

            DoWorkEvery5Seconds((state) =>
            {
                Console.WriteLine($"{i / --j}");
            });
            */

            DoWorkEvery5Seconds((state) => Console.WriteLine("message"));

            Trim(null);

            Thread.Sleep(5000);
        }

        private static void DoWorkEvery5Seconds(TimerCallback callback)
        {   
            /*
            Timer timer;
            try 
            {
                timer = new Timer(callback, null, 0, 1000);
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Console.WriteLine($"Finished");
            }
            finally
            {
                timer?.Dispose();
            }
            */

            //the same as:
            using var timer = new Timer(callback, null, Timeout.Infinite, 0);
            timer.Change(TimeSpan.Zero, TimeSpan.FromSeconds(1));
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine($"Finished");

        }
        // str == null ? null : str.Trim() the same as 
        private static string Trim(string str) => str?.Trim();
    }
}
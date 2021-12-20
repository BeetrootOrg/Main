using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            ShowMessageEvery5Seconds("message");
            Thread.Sleep(5000);
        }

        private static void ShowMessageEvery5Seconds(string message)
        {
            var timer = new Timer(Callback, null, 0, 1000);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine("FINISHED");
            timer.Dispose();

            void Callback(object state)
            {
                Console.WriteLine(message);
            }
        }
    }
}
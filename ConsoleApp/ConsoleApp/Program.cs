using System;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            //var i = 5;
            //var j = 2;

            //DoWorkEvery5Seconds((state) =>
            //{
            //    Console.WriteLine($"{i / --j}");
            //});

            DoWorkEvery5Seconds((state) => Console.WriteLine("message"));

            Thread.Sleep(5000);
        }

        private static void DoWorkEvery5Seconds(TimerCallback callback)
        {
            //Timer timer;
            //try
            //{
            //    timer = new Timer(callback, null, 0, 1000);
            //    Thread.Sleep(TimeSpan.FromSeconds(5));
            //    Console.WriteLine("FINISHED");
            //}
            //finally
            //{
            //    timer?.Dispose();
            //}

            // the same as above
            using var timer = new Timer(callback, null, Timeout.Infinite, 0);
            timer.Change(TimeSpan.Zero, TimeSpan.FromSeconds(1));
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine("FINISHED");
        }
    }
}
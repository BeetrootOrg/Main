using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var sw = new Stopwatch();

            sw.Start();
            BoilWater();
            PourACupOfCoffee();
            HeatUpAPen();
            FryTwoEggs();
            FryABacon();
            MakeAToast();
            AddButterToAToast();
            AddJamToAToast();
            PourAGlassOfWater();
            Eat();
            sw.Stop();

            Console.WriteLine($"Breakfast finished in {sw.Elapsed}");
        }

        private static void BoilWater()
        {
            Task.Delay(5000).Wait();
            Console.WriteLine("Water boiled");
        }

        private static void PourACupOfCoffee()
        {
            Task.Delay(1000).Wait();
            Console.WriteLine("Coffee ready");
        }

        private static void HeatUpAPen()
        {
            Task.Delay(2000).Wait();
            Console.WriteLine("Pen ready");
        }

        private static void FryTwoEggs()
        {
            Task.Delay(6000).Wait();
            Console.WriteLine("Eggs ready");
        }

        private static void FryABacon()
        {
            Task.Delay(4000).Wait();
            Console.WriteLine("Bacon ready");
        }

        private static void MakeAToast()
        {
            Task.Delay(1000).Wait();
            Console.WriteLine("Toast made");
        }

        private static void AddButterToAToast()
        {
            Task.Delay(500).Wait();
            Console.WriteLine("Buttern on a toast");
        }

        private static void AddJamToAToast()
        {
            Task.Delay(500).Wait();
            Console.WriteLine("Jam on a toast");
        }

        private static void PourAGlassOfWater()
        {
            Task.Delay(500).Wait();
            Console.WriteLine("Glass of water ready");
        }

        private static void Eat()
        {
            Task.Delay(10000).Wait();
            Console.WriteLine("Ate");
        }
    }
}
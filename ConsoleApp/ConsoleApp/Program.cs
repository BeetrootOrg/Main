using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main()
        {
            var sw = new Stopwatch();

            sw.Start();

            var boilTask = BoilWater();
            var feedACat = FeedACat();
            var heatUpAPenTask = HeatUpAPen();
            var toastTask = MakeAToast();
            var glassOfWater = PourAGlassOfWater();

            Scream();

            await feedACat;

            await toastTask;
            await AddButterToAToast();
            await AddJamToAToast();

            await heatUpAPenTask;
            var eggsTask = FryTwoEggs();
            var baconTask = FryABacon();

            await boilTask;
            await PourACupOfCoffee();

            await Task.WhenAll(eggsTask, baconTask, glassOfWater);

            await Eat();
            sw.Stop();

            Console.WriteLine($"Breakfast finished in {sw.Elapsed}");
        }

        private static async Task BoilWater()
        {
            await Task.Yield();

            // long await sync task
            Task.Delay(5000).Wait();
            await Task.Delay(5000);
            Console.WriteLine("Water boiled");
        }

        private static async Task PourACupOfCoffee()
        {
            await Task.Delay(1000);
            Console.WriteLine("Coffee ready");
        }

        private static async Task HeatUpAPen()
        {
            await Task.Delay(2000);
            Console.WriteLine("Pen ready");
        }

        private static async Task FryTwoEggs()
        {
            await Task.Delay(6000);
            Console.WriteLine("Eggs ready");
        }

        private static async Task FryABacon()
        {
            await Task.Delay(4000);
            Console.WriteLine("Bacon ready");
        }

        private static async Task MakeAToast()
        {
            await Task.Delay(1000);
            Console.WriteLine("Toast made");
        }

        private static async Task AddButterToAToast()
        {
            await Task.Delay(500);
            Console.WriteLine("Butter on a toast");
        }

        private static async Task AddJamToAToast()
        {
            await Task.Delay(500);
            Console.WriteLine("Jam on a toast");
        }

        private static async Task PourAGlassOfWater()
        {
            await Task.Delay(500);
            Console.WriteLine("Glass of water ready");
        }

        private static async Task Eat()
        {
            await Task.Delay(10000);
            Console.WriteLine("Ate");
        }

        private static Task FeedACat()
        {
            Console.WriteLine("Cat already got food");
            return Task.CompletedTask;
        }

        private static void Scream()
        {
            Task.Delay(500).Wait();
            Console.WriteLine("AAAAAAAAA");
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp
    //i.safontev/classwork/23-async
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
            var screamTask = ScreamASync();

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

            //long await sync task
            Task.Delay(5000).Wait();
            await Task.Delay(5000); 
            Console.WriteLine($"Water boiled");
        }

        private static async Task PourACupOfCoffee()
        {
            await Task.Delay(1000);
            Console.WriteLine($"Coffe ready");
        }

        private static async Task HeatUpAPen()
        {
            await Task.Delay(2000);
            Console.WriteLine($"Pe ready");
        }

        private static async Task FryTwoEggs()
        {
            await Task.Delay(6000);
            Console.WriteLine($"Eggs ready");
        }

        private static async Task FryABacon()
        {
            await Task.Delay(4000);
            Console.WriteLine($"Bacon ready");
        }

        private static async Task MakeAToast()
        {
            await Task.Delay(1000);
            Console.WriteLine($"Toast ready");
        }

        private static async Task AddButterToAToast()
        {
            await Task.Delay(500);
            Console.WriteLine($"Butter added");
        }

        private static async Task AddJamToAToast()
        {
            await Task.Delay(500);
            Console.WriteLine($"Jam added");
        }

        private static async Task PourAGlassOfWater()
        {
            await Task.Delay(500);
            Console.WriteLine($"Glass of water ready");
        }

        private static async Task Eat()
        {
            await Task.Delay(10000);
            Console.WriteLine($"Eat it all");
        }

        private static Task FeedACat()
        {
            Console.WriteLine($"Cat already got food");
            return Task.CompletedTask;
        }

        private static void Scream()
        {
            ScreamASync().Wait();
        }

        private static Task ScreamASync()
        {
            return Task.Run(() =>
            {
                Task.Delay(500).Wait();
                Console.WriteLine($"AAAAAAAAA");
            });
        }
    }
}
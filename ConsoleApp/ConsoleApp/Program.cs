using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Random rand = new((int)DateTime.Now.Ticks);

            Console.WriteLine("Start the game");
            while (true)
            {
                var name = Console.ReadLine();
                var random = rand.Next(0, 6);
                if (random == 0)
                {
                    Console.WriteLine($"{name}, you killed!");
                    break;
                }
                else
                {
                    Console.WriteLine($"{name} continues game...");
                }
            }
        }
    }
}
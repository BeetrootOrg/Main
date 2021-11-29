using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("Welcome to Phone Book Application!\n");
            Console.WriteLine("\tMenu");
            Console.WriteLine("\t1. Show all phone book");

            ConsoleKeyInfo ck = Console.ReadKey();
            
            if (ck.Key == ConsoleKey.D1) // '1' == D1
            {
                Console.Clear();
                Console.WriteLine("You entered 1");
            }
        }
    }
}
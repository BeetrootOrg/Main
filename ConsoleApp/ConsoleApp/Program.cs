using System;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Menu();
            }
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Phone Book Application!\n");
            Console.WriteLine("\tMenu");
            Console.WriteLine("\t1. Show all phone book");

            ConsoleKeyInfo ck = Console.ReadKey();
            
            if (ck.Key == ConsoleKey.D1 || ck.Key == ConsoleKey.NumPad1)
            {
                ShowAllNumbers();
                Console.WriteLine("To back to menu type Enter...");
                Console.ReadLine();
            }
        }

        static void ShowAllNumbers()
        {
            Console.Clear();
            string[] lines = File.ReadAllLines("phonebook.csv");

            foreach (string line in lines)
            {
                string[] splitted = line.Split(',');

                foreach (var item in splitted)
                {
                    Console.Write($"{item,-15}");
                }

                Console.WriteLine();
            }
        }
    }
}
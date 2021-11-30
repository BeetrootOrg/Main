using System;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        const string Filename = @"C:\Users\lordh\source\repos\Main\Main\ConsoleAppBeetrootOther\ConsoleAppBeetrootOther";

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
            Console.WriteLine("\t2. Create phone record");
            Console.WriteLine("\t0. Exit");

            ConsoleKeyInfo ck = Console.ReadKey();

            if (ck.Key == ConsoleKey.D1 || ck.Key == ConsoleKey.NumPad1)
            {
                ShowAllNumbers();
                Console.WriteLine("To back to menu type Enter...");
                Console.ReadLine();
            }
            else if (ck.Key == ConsoleKey.D2 || ck.Key == ConsoleKey.NumPad2)
            {
                CreatePhoneNumber();
            }
            else if (ck.Key == ConsoleKey.D0 || ck.Key == ConsoleKey.NumPad0)
            {
                Environment.Exit(0);
            }
        }

        static void CreatePhoneNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter First Name...");
            var firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name...");
            var lastName = Console.ReadLine();

            Console.WriteLine("Enter Phone Number...");
            var phoneNumber = Console.ReadLine();

            File.AppendAllLines(Filename, new[] { $"{firstName},{lastName},{phoneNumber}" });
        }

        static void ShowAllNumbers()
        {
            Console.Clear();
             string[] lines = File.ReadAllLines(Filename);

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
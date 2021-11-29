using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp
{
    public class Program
    {
        const string FileName = "phonebook.csv";
        static void Main()
        {
            while (true)
            {
                Menu();
            }
        }

        static void Menu()
        {
            Console.WriteLine("Welkome to Phone Book Aplication!\n");
            Console.WriteLine("\tMemu");
            Console.WriteLine("\t1. Show all phone book");
            Console.WriteLine("\t2. Create phone record");
            Console.WriteLine("\t3. Search by name");
            Console.WriteLine("\t0. Exit");

            ConsoleKeyInfo ck = Console.ReadKey();

            switch (ck.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                     ShowAllNumbers();
                     break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                     CreatePhoneNumber();
                     break;
                case ConsoleKey.D3:
                     ConsoleKey.NumPad3:
                     ReadPhoneBook();
                     break;
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                     Environment.Exit(0);
                     break;
            }

            static void CreatePhoneNumber()
            {
                Console.Clear();
                Console.WriteLine("Enter First Name...");
                string firstName = Console.ReadLine();

                Console.WriteLine("Enter Last Name...");
                string lastName = Console.ReadLine();

                Console.WriteLine("Enter Phone Number...");
                string phoneNumber = Console.ReadLine();

                File.AppendAllLines(FileName, new[] { $"{firstName},{lastName},{phoneNumber}" }); ;
            }

            static void ShowAllNumbers()
            {
                Console.Clear();
                string[] lines = File.ReadAllLines("phonebook.csv");

                foreach (string line in lines)
                {
                    string[] splitted = line.Split(',');

                    foreach (string item in splitted)
                    {
                        Console.Write($"{item,-15}");
                    }

                    Console.WriteLine();
                }
            }

            static (string , string , string)[] ReadPhoneBook()
            {
                string[] lines = File.ReadAllLines(FileName);

                var phoneBook = new (string, string, string)[lines.Length - 1];
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] splitted = lines[i].Split(',');
                    phoneBook[i-1] = (splitted[0], splitted[1], splitted[2]);
                }
                return phoneBook;
            }

        }
    }
}
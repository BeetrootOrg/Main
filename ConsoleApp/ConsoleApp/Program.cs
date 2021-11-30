using System;
using System.Text;
using System.IO;
namespace ConsoleApp
{
    class Program
    {
        const string Filename = @"phonebook.csv";

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
                case ConsoleKey.NumPad3:
                    SearchByName();
                    break;
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Exit();
                    break;
            }
        }

        private static void SearchByName()
        {
            Console.Clear();
            Console.WriteLine("Search condition - if first/last name contains search term you will see it");
            Console.WriteLine("Enter Search Term...");
            var searchTerm = Console.ReadLine();

            bool found = false;
            foreach (var (firstName, lastName, phoneNumber) in ReadPhoneBook())
            {
                if (firstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    lastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Found user {firstName} {lastName} with phone {phoneNumber}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Not such users");
            }

            Wait();
        }

        private static void Exit()
        {
            Environment.Exit(0);
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
            Console.WriteLine($"{"First Name",-15}{"Last Name",-15}{"Phone Number",-15}");

            foreach (var (firstName, lastName, phoneNumber) in ReadPhoneBook())
            {
                Console.Write($"{firstName,-15}");
                Console.Write($"{lastName,-15}");
                Console.Write($"{phoneNumber,-15}");
                Console.WriteLine();
            }

            Wait();
        }

        private static void Wait()
        {
            Console.WriteLine("To back to menu type Enter...");
            Console.ReadLine();
        }

        static (string, string, string)[] ReadPhoneBook()
        {
            string[] lines = File.ReadAllLines(Filename);

            var phoneBook = new (string, string, string)[lines.Length - 1];
            for (int i = 1; i < lines.Length; i++)
            {
                string[] splitted = lines[i].Split(',');
                phoneBook[i - 1] = (splitted[0], splitted[1], splitted[2]);
            }

            return phoneBook;
        }
    }  
}

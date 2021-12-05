using System;
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
            Console.WriteLine("\t4. Search by number");
            Console.WriteLine("\t5. Update number");
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
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    SearchBy();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    TryUpdateNumber();
                    break;
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Exit();
                    break;
            }
        }

        private static void TryUpdateNumber()
        {
            Console.Clear();
            Console.WriteLine("You must enter first and last name correct to update phone number");

            Console.WriteLine("Enter first name...");
            var searchFirstName= Console.ReadLine();
            Console.WriteLine("Enter last name...");
            var searchLastName = Console.ReadLine();

            bool found = false;
            foreach (var (firstName, lastName, phoneNumber) in ReadPhoneBook())
            {
                if (searchFirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                    searchLastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"You can update phone nubmer. Please write it:");
                    var newPhoneNumber= Console.ReadLine();
                    Modify(firstName, lastName,newPhoneNumber);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Not such users");
            }

            Wait();
        }

        static void Modify(string firstName, string lastName, string newPhoneNumber)
        {
            string[] lines = File.ReadAllLines(Filename);
            string[] newPhoneBook = new string [lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                
                string[] splitted = lines[i].Split(',');
                if (splitted[0]==firstName && splitted[1]==lastName)
                { 
                    lines[i]= String.Join(",",splitted[0], splitted[1], newPhoneNumber);
                }
                newPhoneBook[i] = lines[i];

            }
            File.WriteAllLines(Filename, newPhoneBook);
        }

        private static void SearchBy(bool phone = true)
        {
            Console.Clear();
            Console.WriteLine("Search condition - if first/last name/phone number contains search term you will see it");

            Console.WriteLine("Enter Search Term...");
            var searchTerm = Console.ReadLine();

            bool found = false;
            foreach (var (firstName, lastName, phoneNumber) in ReadPhoneBook())
            {
                if (firstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    lastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    phoneNumber.Contains(searchTerm))
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
            // show header
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
                phoneBook[i-1] = (splitted[0], splitted[1], splitted[2]);
            }

            return phoneBook;
        }
    }
}
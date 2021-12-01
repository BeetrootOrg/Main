using System;
using System.IO;
using System.Text;

namespace Course
{
    class Course
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
            Console.WriteLine("Welcome to the Club, buddy!\n");

            Console.WriteLine("\tMenu");
            Console.WriteLine("\t1. Show all phone contacts");
            Console.WriteLine("\t2. Create phone contact");
            Console.WriteLine("\t3. Search by name");
            Console.WriteLine("\t4. Search by phone number");
            Console.WriteLine("\t5. Modify contact");
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
                    SearchBy(true);
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    SearchBy();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    ModifyContact();
                    break;
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Exit();
                    break;
            }
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

        static void SearchBy(bool byName = false)
        {
            Console.Clear();
            Console.WriteLine("Search condition - {0}", byName ? "if first/last name contains search term" : "if entered number(s) exist in any contact");

            Console.WriteLine("Enter Search Term...");
            var searchTerm = Console.ReadLine();

            bool found = false;
            foreach (var (firstName, lastName, phoneNumber) in ReadPhoneBook())
            {
                if (byName)
                {
                    if (firstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        lastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Found user {firstName} {lastName} with phone {phoneNumber}");
                        found = true;
                    }
                } else
                {
                    if (phoneNumber.Contains(searchTerm))
                    {
                        Console.WriteLine($"Found user {firstName} {lastName} with phone {phoneNumber}");
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("No user found!");
            }

            Wait();
        }

        static void ModifyContact()
        {
            Console.Clear();
            var phoneBook = ReadPhoneBook();
            int index = 0;
            (string, string, string) userData = ("", "", "");
            Console.WriteLine("Please, write full the first and the last name of the user");

            Console.WriteLine("Enter Search Term...");
            var searchTerm = Console.ReadLine();

            bool found = false;
            foreach (var (firstName, lastName, phoneNumber) in phoneBook)
            {
                if ($"{firstName} {lastName}".Equals(searchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    userData = ( firstName, lastName, phoneNumber );
                    found = true;
                }
                if (!found)
                {
                    index++;
                }
            }

            if (index == phoneBook.Length && !found)
            {
                Console.WriteLine("No user found!");
            } else
            {
                Console.WriteLine("Please, write new phone number");
                string newPhoneNumber = Console.ReadLine();
                userData.Item3 = newPhoneNumber;

                phoneBook[index] = userData;

                string[] covertedPhoneBook = new string[phoneBook.Length];
                for (int i = 0; i < phoneBook.Length; i++)
                {
                    covertedPhoneBook[i] = $"{phoneBook[i].Item1},{phoneBook[i].Item2},{phoneBook[i].Item3}";
                }

                File.WriteAllLines(Filename, covertedPhoneBook);
            }

            Wait();
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static void Wait()
        {
            Console.WriteLine("\nPress Enter to return to menu...");
            Console.ReadLine();
        }
    }
}

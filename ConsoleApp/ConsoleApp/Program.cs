using System;
using System.IO;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        const string WrongFilename = @"asda/phonebook.csv";
        const string Filename = @"phonebook.csv";
        const string Header = "FirstName,LastName,PhoneNumber";
        const int MaxStringLength = 14;

        static void Main()
        {
            while (true)
            {
                try
                {
                    Menu();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Wait();
                }
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
            Console.WriteLine("\t4. Search by phone number");
            Console.WriteLine("\t5. Edit phone number");
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
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    SearchByPhoneNumber();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    ChangeUserPhone();
                    break;
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Exit();
                    break;
            }
        }

        private static void ChangeUserPhone()
        {
            Console.Clear();
            Console.WriteLine("Search condition - if first/last name equals search term you will see it");
            Console.WriteLine("Enter full First/Last Name...");
            var searchTerm = Console.ReadLine();
            bool found = false;
            string[] lines = File.ReadAllLines(Filename);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] splitted = lines[i].Split(',');
                if (splitted[0].Equals(searchTerm, StringComparison.OrdinalIgnoreCase) || splitted[1].Equals(searchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Found user {splitted[0]} {splitted[1]} with phone {splitted[2]}");
                    Console.WriteLine("Enter New Phone Number...");
                    var newPhoneNumber = Console.ReadLine();
                    int number;
                    bool checkIfNumber = int.TryParse(newPhoneNumber, out number);
                    if (newPhoneNumber.Length > MaxStringLength)
                    {
                        throw new ArgumentException($"Max length of phone number is {MaxStringLength}", nameof(newPhoneNumber));
                    }

                    if (!checkIfNumber)
                    {
                        throw new ArgumentException($"Only numbers allowed", nameof(newPhoneNumber));
                    }
                    splitted[2] = newPhoneNumber;
                    lines[i] = string.Join(",", splitted);
                    found = true;
                }
                else
                {
                    SearchWait(ChangeUserPhone);
                }

            }
            File.WriteAllLines(Filename, lines);
        }

        private static void SearchByPhoneNumber()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Search condition - if phone number contains search input you will see it");
                Console.WriteLine("Enter Search Input...");
                var searchTerm = Console.ReadLine();
                bool found = false;
                var phoneBook = ReadPhoneBook(Filename);

                if (phoneBook == null)
                {
                    Console.WriteLine("Error occured during file read.");
                    return;
                }

                foreach (var (firstName, lastName, phoneNumber) in phoneBook)
                {
                    if (phoneNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Found user {firstName} {lastName} with phone {phoneNumber}");
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("No such users");
                }
            }
            finally
            {
                SearchWait(SearchByPhoneNumber);
            }
        }


        private static void SearchByName()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Search condition - if first/last name contains search term you will see it");
                Console.WriteLine("Enter Search Term...");
                var searchTerm = Console.ReadLine();
                bool found = false;
                var phoneBook = ReadPhoneBook(Filename);

                if (phoneBook == null)
                {
                    Console.WriteLine("Error occured during file read.");
                    return;
                }

                foreach (var (firstName, lastName, phoneNumber) in phoneBook)
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
                    Console.WriteLine("No such users");
                }
            }
            finally
            {
                SearchWait(SearchByName);
            }
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

            if (firstName.Length > MaxStringLength)
            {
                throw new ArgumentException($"Max length of first name is {MaxStringLength}", nameof(firstName));
            }

            Console.WriteLine("Enter Last Name...");
            var lastName = Console.ReadLine();

            if (lastName.Length > MaxStringLength)
            {
                throw new ArgumentException($"Max length of last name is {MaxStringLength}", nameof(lastName));
            }

            Console.WriteLine("Enter Phone Number...");
            var phoneNumber = Console.ReadLine();

            if (phoneNumber.Length > MaxStringLength)
            {
                throw new ArgumentException($"Max length of phone number is {MaxStringLength}", nameof(phoneNumber));
            }

            File.AppendAllLines(Filename, new[] { $"{firstName},{lastName},{phoneNumber}" });
        }

        static void ShowAllNumbers()
        {
            Console.Clear();

            var phoneBook = ReadPhoneBook(WrongFilename);
            if (phoneBook == null)
            {
                Console.WriteLine("Error occured during file read, press Enter...");
                Console.ReadLine();
                return;
            }

            // show header
            Console.WriteLine($"{"First Name",-15}{"Last Name",-15}{"Phone Number",-15}");

            foreach (var (firstName, lastName, phoneNumber) in phoneBook)
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
            Console.WriteLine("To back to menu press Enter...");
            Console.ReadLine();
        }
        private static void SearchWait(Action SearchType)
        {
            Console.WriteLine("To back to menu press Enter");
            Console.WriteLine("Want to search more? Press 9");
            ConsoleKeyInfo ck = Console.ReadKey();
            switch (ck.Key)
            {
                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    SearchType();
                    break;
                case ConsoleKey.Enter:
                    Menu();
                    break;
            }
        }

        /// <summary>
        /// Parse CSV file to Phone Book
        /// </summary>
        /// <returns>array if read was success, null if error occures</returns>
        static (string, string, string)[] ReadPhoneBook(string EnteredFilename)
        {
            try
            {
                string[] lines = File.ReadAllLines(EnteredFilename);

                var phoneBook = new (string, string, string)[lines.Length - 1];
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] splitted = lines[i].Split(',');
                    phoneBook[i - 1] = (splitted[0], splitted[1], splitted[2]);
                }

                return phoneBook;
            }
            // throw new DirectoryNotFoundException(...) -> dnfe;
            catch (DirectoryNotFoundException dnfe)
            {
                Console.WriteLine($"Hey, unfortunately this directory wasn't found. Here is our default phonebook:\n");
                return ReadPhoneBook(Filename);
            }
            catch (IOException)
            {
                File.WriteAllText(EnteredFilename, $"{Header}\n");
                return new (string, string, string)[0];
            }
            catch
            {
                return null;
            }
        }

    }
}
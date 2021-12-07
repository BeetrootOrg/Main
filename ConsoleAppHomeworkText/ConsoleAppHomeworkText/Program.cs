using System;
using System.IO;

namespace ConsoleApp
{
    //додати можливість шукати за номером телефону
    //додати можливість оновлювати номер телефону за іменем/прізвищем користувача(ім'я/прізвище вводити повністю, але реєстр не важливий)
    //P.S.:
    //для другого завдання спробуйте метод File.WriteAllText or File.WriteAllLines
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
            Console.WriteLine("\t4. Update number");
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
                    UpdateNumber();
                    break;
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Exit();
                    break;
            }
        }
        private static void UpdateNumber()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Please insert a new number");
                string updatedNumber = Console.ReadLine();
                Console.WriteLine("Search condition - if first/last name contains search term you will see it");
                if (updatedNumber == string.Empty)
                {
                    throw new Exception("This string is empty");
                }
                Console.WriteLine("Enter Search Term...");
                var searchTerm = Console.ReadLine();
                bool find = false;
                var lines = ReadPhoneBook();
                var linesUpdated = "FirstName,LastName,PhoneNumber\n";
                for (int i = 0; i < lines.Length; i++)
                {
                    (string firstName, string lastName, string phoneNumber) current = lines[i];
                    if (current.firstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        current.lastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    {
                        current.phoneNumber = updatedNumber;
                        Console.WriteLine($"Number for {current.firstName} {current.lastName} successfully changed");
                    }
                    linesUpdated += $"{current.firstName},{current.lastName},{current.phoneNumber} \n";
                }

                File.WriteAllText(Filename, linesUpdated);

                if (!find)
                {
                    Console.WriteLine("Not such users");
                    Wait();
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                UpdateNumber();
            }
        }
        //додати можливість оновлювати номер телефону за іменем/прізвищем користувача(ім'я/прізвище вводити повністю, але реєстр не важливий)
        private static bool SearchByNumber(string search = null)
        {
            Console.Clear();
            if (search == null)
            {
                search = Console.ReadLine();
            }

            bool found = false;
            foreach (var (firstName, lastName, phoneNumber) in ReadPhoneBook())
            {
                if (phoneNumber.ToLower() == search.ToLower())
                {
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Not such users");
            }
            return found;
        }
        private static void SearchByName()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Search condition - if first/last name contains search term you will see it");

                Console.WriteLine("Enter Search Term...");
                var searchTerm = Console.ReadLine();
                if (searchTerm == string.Empty)
                {
                    throw new Exception("Your search is empty, please write something");
                }
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                SearchByName();
            }
           
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        static void CreatePhoneNumber()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter First Name...");
                var firstName = Console.ReadLine();

                Console.WriteLine("Enter Last Name...");
                var lastName = Console.ReadLine();

                Console.WriteLine("Enter Phone Number...");
                var phoneNumber = Console.ReadLine();
                if (firstName == string.Empty || lastName == string.Empty)
                {
                    throw new ArgumentException("First or Last Name is empty");
                }
                if (SearchByNumber(phoneNumber))
                {
                    throw new ArgumentException("This number already exists");
                }

                File.AppendAllLines(Filename, new[] { $"{firstName},{lastName},{phoneNumber}" });
            }
            catch (ArgumentException exe)
            {
                Console.WriteLine(exe.Message);
                Console.ReadKey();
                CreatePhoneNumber();
            }
           
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
                phoneBook[i - 1] = (splitted[0], splitted[1], splitted[2]);
            }

            return phoneBook;
        }

        static string[] ConvertToText((string, string, string)[] data)
        {
            var content = new string[data.Length + 1];
            content[0] = "FirstName,LastName,PhoneNumber";

            for (int i = 0; i < data.Length; i++)
            {
                content[i + 1] = $"{data[i].Item1},{data[i].Item2},{data[i].Item3}";
            }

            return content;
        }
       
    }
}
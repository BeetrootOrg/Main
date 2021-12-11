
using System;
using System.IO;
using System.Globalization;

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
            Console.WriteLine("\t4. Search by phone");
            Console.WriteLine("\t5. Update phone");
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
                    SearchByPhone();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    SearchByName(true);
                    break;
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Exit();
                    break;
            }
        }

        private static void SearchByName(bool update = false)
        {
            Console.Clear();
            Console.WriteLine("Search condition - if first/last name contains search term you will see it");

            Console.WriteLine("Enter Search Term...");
            var items = new List<int>();
            var searchTerm = Console.ReadLine();

            bool found = false;
            int i = 0;
            int j = 0;
            foreach (var (firstName, lastName, phoneNumber) in ReadPhoneBook())
            {
                i++;
                if (firstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    lastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    j++;
                    Console.WriteLine($"{j}. Found user {firstName} {lastName} with phone {phoneNumber}");
                    found = true;
                    items.Add(i);
                }
            }

            if (!found)
            {
                Console.WriteLine("Not such users");
            }
            if (update)
            {
                if (items.Count > 0)
                {
                    SelectUser(items);
                }

            }
            else
            {
                Wait();
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

        private static void SelectUser(List<int> x)
        {
            Console.WriteLine();
            Console.WriteLine(" Type number from 1 to {0} corresponding to user, which phonenumber You want to change, or  type Enter To back to menu", x.Count);
            //int selectedUser = Convert.ToInt16(Console.ReadLine());
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                int selectedUser = int.Parse(input);
                int selectedUserRecordNumber = x[selectedUser - 1] - 1;
                if (selectedUser > 0)
                {
                    (string, string, string)[] phoneBook = ReadPhoneBook();
                    Console.WriteLine("type new phonenumber for {0} {1}", phoneBook[selectedUserRecordNumber].Item1, phoneBook[selectedUserRecordNumber].Item2);
                    string newNumber = Console.ReadLine();
                    PhoneNumberUpdate(selectedUserRecordNumber, newNumber);
                }
                Wait();
            }

        }
        private static void PhoneNumberUpdate(int iD, string number)
        {
            string[] lines = File.ReadAllLines(Filename);
            (string, string, string)[] phoneBook = ReadPhoneBook();
            phoneBook[iD].Item3 = number;
            lines[iD + 1] = String.Join(",", phoneBook[iD].Item1, phoneBook[iD].Item2, phoneBook[iD].Item3);
            File.WriteAllLines(Filename, lines);
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


        /////////////////search by phone
        private static void SearchByPhone(string search = null)
        {
            Console.Clear();

        Begin:
            Console.WriteLine("Enter a phone number, please");




            if (search == null)
            {
                search = Console.ReadLine();
            }

            try
            {

                string val = Convert.ToString(int.Parse(search, NumberStyles.AllowLeadingSign));

            }

            catch (Exception e)
            {
                Console.WriteLine("the entered value is not a valid phone number");
                search = null;
                goto Begin;
            }

            bool found = false;
            foreach (var (firstName, lastName, phoneNumber) in ReadPhoneBook())

            {
                if (string.Equals(phoneNumber.Trim(), search.Trim()))
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



    }
}

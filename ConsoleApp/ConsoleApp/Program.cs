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
            Console.Clear();
            Console.WriteLine("Welkome to Phone Book Aplication!\n");
            Console.WriteLine("\tMenu:");
            Console.WriteLine("\t1. Show all phone book");
            Console.WriteLine("\t2. Create phone record");
            Console.WriteLine("\t3. Search by name");
            Console.WriteLine("\t4. Search by phone");
            Console.WriteLine("\t5. Update phone number");
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
                    UpdatePhoneNumber();
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

                Wait();
            }

            static (string, string, string)[] ReadPhoneBook()
            {
                string[] lines = File.ReadAllLines(FileName);

                var phoneBook = new (string, string, string)[lines.Length - 1];
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] splitted = lines[i].Split(',');
                    phoneBook[i - 1] = (splitted[0], splitted[1], splitted[2]);
                }

                return phoneBook;
            }

            static void SearchByName()
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

            //Search by Phone Number
            //Similar to SearchByName() 
            static void SearchByPhoneNumber()
            {
                Console.Clear();
                Console.WriteLine("Search condition - if phone number contains search digits we will find phone number ");

                Console.WriteLine("Enter numbers...");
                var searchTerm = Console.ReadLine();
                bool found = false;

                foreach (var (firstName, lastName, phoneNumber) in ReadPhoneBook())
                {
                    if (phoneNumber.Contains(searchTerm))
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

            static void UpdatePhoneNumber()
            {
                Console.Clear();

                Console.WriteLine("Write the FirstName and LastName where we will change the phone ");
                string lookFirstName = Console.ReadLine();
                string lookLastName = Console.ReadLine();

                Console.WriteLine("\nWrite new PHONE NUMBER:");
                string newPhoneNumber = Console.ReadLine();

                bool found = false;
                (string firstName, string lastName, string phoneNumber)[] phoneBook = ReadPhoneBook();

                for(int i = 0; i < phoneBook.Length; i++)
                {
                    if (phoneBook[i].firstName.ToLower() == lookFirstName.ToLower() && phoneBook[i].lastName.ToLower() == lookLastName.ToLower())
                    {
                        phoneBook[i].phoneNumber = newPhoneNumber;
                        found = true;
                    }
                }

                if (found)
                {
                    string[] newPhoneBook = new string[phoneBook.Length + 1];
                    newPhoneBook[0] = "FirstName,LastName,PhoneNumber";

                    for (int i = 0; i < phoneBook.Length; i++)
                    {
                        newPhoneBook[i + 1] = String.Join(',', phoneBook[i].firstName, phoneBook[i].lastName, phoneBook[i].phoneNumber);
                    }

                    File.WriteAllLines(FileName, newPhoneBook);
                }
                else Console.WriteLine("This user not exist!!!");

                Wait();
            }


            static void Wait()
            {
                Console.WriteLine("To back to menu type Enter...");
                Console.ReadLine();
            }
        }
    }
}
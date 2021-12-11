﻿using System;
using System.IO;

namespace ConsoleApp
{
    public class Program
    {
        const string Filename = "phonebook.csv";
        const string Head = "FirstName,LastName,PhoneNumber";

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
            Console.WriteLine("\t4. Search by phone number");
            Console.WriteLine("\t5. Rerecord phone number of some user");
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
                    SearchByNumber();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    RerecordNumber();
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
        private static void SearchByNumber()
        {
            Console.Clear();
            Console.WriteLine("Search condition - if phone number contains search term you will see it");

            Console.WriteLine("Enter Search Term...");
            var searchTerm = Console.ReadLine();

            bool found = false;
            foreach (var (firstName, lastName, phoneNumber) in ReadPhoneBook())
            {
                if (phoneNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
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
        private static void RerecordNumber()
        {
            Console.Clear();

            Console.WriteLine("Write the first name and last name of the user to change the phone number\n");
            Console.WriteLine("First name:");
            string lookFirstName = Console.ReadLine();
            Console.WriteLine("Second name:");
            string lookLastName = Console.ReadLine();

            bool found = false;
            (string firstName, string lastName, string phoneNumber)[] phoneBook = ReadPhoneBook();

            for (int i = 0; i < phoneBook.Length; ++i)
            {

                if (String.Equals(lookFirstName, phoneBook[i].firstName, StringComparison.OrdinalIgnoreCase) &&
                    String.Equals(lookLastName, phoneBook[i].lastName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nWrite new phone number:");
                    phoneBook[i].phoneNumber = Console.ReadLine();

                    string[] newPhoneBook = new string[phoneBook.Length + 1];
                    newPhoneBook[0] = Head;

                    for (int j = 0; j < phoneBook.Length; j++)
                    {
                        newPhoneBook[j + 1] = String.Join(',', phoneBook[j].firstName, phoneBook[j].lastName, phoneBook[j].phoneNumber);
                    }

                    File.WriteAllLines(Filename, newPhoneBook);

                    Console.WriteLine("Update successfuly done");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("This user doesn`t exist");
            }

            Wait();
        }

    }
}
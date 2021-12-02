﻿using System;
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
            Console.WriteLine("\t4. Search by phone number");
            Console.WriteLine("\t5. Update user");
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
                    UpdateUser();
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
            foreach (var (number, firstName, lastName, phoneNumber) in ReadPhoneBook())
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

        private static void SearchByPhoneNumber()
        {
            Console.Clear();
            Console.WriteLine("Search by the name.");
            Console.WriteLine("Pls enter the phone nuber");

            var searchTerm = Console.ReadLine();

            bool found = false;
            foreach (var (number, firstName, lastName, phoneNumber) in ReadPhoneBook())
            {
                if (phoneNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    
                {
                    Console.WriteLine($"Found user {firstName} {lastName} with phone number: {phoneNumber}");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Not such users");
            }

            Wait();
        }

        private static void UpdateUser()
        {
            Console.Clear();
            bool found = false;
            // show header
            Console.WriteLine($"{"#",-15}{"First Name",-15}{"Last Name",-15}{"Phone Number",-15}");

            foreach (var (number, firstName, lastName, phoneNumber) in ReadPhoneBook())
            {
                Console.Write($"{number,-15}");
                Console.Write($"{firstName,-15}");
                Console.Write($"{lastName,-15}");
                Console.Write($"{phoneNumber,-15}");
                Console.WriteLine();
            }

            Console.WriteLine("\nWitch user are you want to rename? (write the number of them)\n");
            var searchTerm = Console.ReadLine();

            Console.Clear();

            foreach (var(number,firstName,lastName,phoneNumber) in ReadPhoneBook())
            {
                if(number.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    Console.WriteLine("Enter First Name...");
                    var firstNameChanger = Console.ReadLine();

                    Console.WriteLine("Enter Last Name...");
                    var lastNameChanger = Console.ReadLine();

                    File.WriteAllLines(Filename , new[] { $"{firstNameChanger}, {lastNameChanger}" });                    
                }
                else
                {
                    Console.WriteLine("This user is not found!");
                }
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


            File.AppendAllLines(Filename, new[]  { $"{firstName},{lastName},{phoneNumber}" });
        }

        static void ShowAllNumbers()
        {
            Console.Clear();
            // show header
            Console.WriteLine($"{"#",-15}{"First Name",-15}{"Last Name",-15}{"Phone Number",-15}");

            foreach (var (number ,firstName, lastName, phoneNumber) in ReadPhoneBook())
            {
                Console.Write($"{number,-15}");
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

        static (string, string, string, string)[] ReadPhoneBook()
        {
            string[] lines = File.ReadAllLines(Filename);

            var phoneBook = new (string,string, string, string)[lines.Length - 1];
            for (int i = 1; i < lines.Length; i++)
            {
                string[] splitted = lines[i].Split(',');
                phoneBook[i - 1] = (splitted[0], splitted[1], splitted[2], splitted[3]);
            }

            return phoneBook;
        }

        static string[] ConvertToText((string,string, string, string)[] data)
        {
            var content = new string[data.Length + 1];
            content[0] = "#,FirstName,LastName,PhoneNumber";

            for (int i = 0; i < data.Length; i++)
            {
                content[i + 1] = $"{data[i].Item1},{data[i].Item2},{data[i].Item3},{data[i].Item4}";
            }

            return content;
        }
    }
}
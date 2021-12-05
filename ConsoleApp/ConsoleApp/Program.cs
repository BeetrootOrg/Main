using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp
{
    public class Program
    {
        const string FileName = "phonebook.csv";
        const string Head = "FirstName,LastName,PhoneNumber";
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
                    Console.Read();

                }
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
                try
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
                catch(FileNotFoundException fnfe)
                {
                    Console.WriteLine("File not exist, you need to create your PHONEBOOK at first.");
                    throw fnfe;
                }
                catch(DirectoryNotFoundException dnfe)
                {
                    Console.WriteLine("Directory not found.");
                    throw dnfe;
                }
            }

            static void SearchByName()
            {
                Console.Clear();
                Console.WriteLine("Search condition - if first/last name contains search term you will see it");

                Console.WriteLine("Enter Search Term...");
                string searchTerm = null;
                
                //Checking searchTerm on empty string
                try
                {
                    searchTerm = Console.ReadLine();
                    if (String.IsNullOrEmpty(searchTerm))
                        throw new ArgumentException();
                }
                catch(ArgumentException)
                {
                    while (String.IsNullOrEmpty(searchTerm))
                    {
                        Console.WriteLine("You didn't write term to serch, but you have the second chance!!! Write term correct...");
                        searchTerm = Console.ReadLine();
                    }
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

            //Search by Phone Number
            //Similar to SearchByName() 
            static void SearchByPhoneNumber()
            {
                Console.Clear();
                Console.WriteLine("Search condition - if phone number contains search digits we will find phone number ");

                Console.WriteLine("Enter numbers...");
                string searchTerm = null;

                //Checking searchTerm on empty string
                try
                {
                    searchTerm = Console.ReadLine();
                    if (String.IsNullOrEmpty(searchTerm))
                        throw new ArgumentException();
                }
                catch (ArgumentException)
                {
                    while (String.IsNullOrEmpty(searchTerm))
                    {
                        Console.WriteLine("You didn't write term to serch, but you have the second chance!!! Write term correct...");
                        searchTerm = Console.ReadLine();
                    }
                }
                finally
                {
                    Console.WriteLine("You write term successful! It is not empty.");
                }

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

                (string firstName, string lastName, string phoneNumber)[] phoneBook = ReadPhoneBook();
                
                //Here we looking our contact and as soon as we found, we change it and write in fle
                if (TrySearchPhone(phoneBook, lookFirstName, lookLastName, out int contactIndex))
                {
                    //If we found the contact we change phone number here
                    Console.WriteLine("\nWrite new PHONE NUMBER:");
                    phoneBook[contactIndex].phoneNumber = Console.ReadLine();

                    string[] newPhoneBook = new string[phoneBook.Length + 1];
                    newPhoneBook[0] = Head;

                    //IndexOutOfRangeException
                    try
                    {
                        for (int j = 0; j < phoneBook.Length; j++)
                        {
                            newPhoneBook[j + 1] = String.Join(',', phoneBook[j].firstName, phoneBook[j].lastName, phoneBook[j].phoneNumber);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Index was out of range. Correct your program.");
                    }

                    File.WriteAllLines(FileName, newPhoneBook);

                    Console.WriteLine("Update is successful!!!");
                }
                else
                {
                    Console.WriteLine("This user not exist!");
                }

                Wait();
            }

            //Method to search looking contact1
            static bool TrySearchPhone((string firstName, string lastName, string phoneNumber)[] phoneBook, string lookFirstName, string lookLastName, out int contactIndex)
            {
                for (int i = 0; i < phoneBook.Length; i++)
                {
                    if (String.Equals(lookFirstName, phoneBook[i].firstName, StringComparison.OrdinalIgnoreCase) &&
                        String.Equals(lookLastName, phoneBook[i].lastName, StringComparison.OrdinalIgnoreCase))
                    {
                        contactIndex = i;
                        return true;
                    }
                }
                contactIndex = 0;
                return false;
            }


            static void Wait()
            {
                Console.WriteLine("To back to menu type Enter...");
                Console.ReadLine();
            }
        }
    }
}
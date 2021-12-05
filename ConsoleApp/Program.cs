namespace ConsoleApp
{
    using System;
    class ConsoleApp
    {
        const string Filename = @"..\..\..\phonebook.csv";

        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/homework/08-Text and 09-Exception \r\n");

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
            Console.WriteLine("\t3. Edit phone record");
            Console.WriteLine("\t4. Search by name");
            Console.WriteLine("\t5. Search by phone");
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
                    EditPhoneNumber();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    SearchByName();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    SearchByPhone();
                    break;
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Exit();
                    break;
            }
        }
        static string[] AddNewElement(string[] array, (string, string, string)[] phoneBook, ref (string lastName, string firstName, string phoneNumber) newElement)
        {
            CheckEnteredParameters(ref newElement.firstName, ref newElement.lastName, ref newElement.phoneNumber);

            int searchResult = BinarySearchByLastName(phoneBook, newElement.lastName);
            if (searchResult != -1)
            {
                throw new Exception("The \"" + newElement.lastName + "\" element, present in the List");
            }

            int newLength = array.Length + 1;

            string[] result = new string[newLength];

            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[i];
            }

            result[newLength - 1] = newElement.lastName + "," + newElement.firstName + "," + newElement.phoneNumber;
            Array.Sort(result, 1, result.Length - 1);

            return result;
        }
        private static void CheckEnteredParameter(ref string Name)
        {
            if (Name.Length > 0)
            {
                if (!char.IsLetter(Name[0]))
                {
                    throw new Exception("\"Name\" - must be begin with the \"Letter\" character!");
                }
            }
            else
            {
                throw new Exception("String \"Length\" Error in \"Name\" !");
            }
        }
        private static void CheckEnteredParameters(ref string firstName, ref string lastName)
        {
            if ((firstName.Length > 0) || (lastName.Length > 0))
            {
                if (!char.IsLetter(firstName[0]) || !char.IsLetter(lastName[0]))
                {
                    throw new Exception("\"First Name\" or/and \"Last Name\" - must be begin with the \"Letter\" character!");
                }
            }
            else
            {
                throw new Exception("String \"Length\" Error in \"First Name\" or/and \"Last Name\"!");
            }
            firstName = firstName.Remove(0, 1).Insert(0, firstName[0].ToString().ToUpper());
            lastName = lastName.Remove(0, 1).Insert(0, lastName[0].ToString().ToUpper());
        }
        private static void CheckEnteredParameters(ref string firstName, ref string lastName, ref string phoneNumber)
        {
            if ((firstName.Length > 0) || (lastName.Length > 0))
            {
                if (!char.IsLetter(firstName[0]) || !char.IsLetter(lastName[0]))
                {
                    throw new Exception("\"First Name\" or/and \"Last Name\" - must be begin with the \"Letter\" character!");
                }
                if (phoneNumber[0] != '+')
                {
                    throw new Exception("\"Phone number\" - must be begin with the \'+\' character!");
                }
                for (int i = 1; i < phoneNumber.Length; i++)
                {
                    if (!char.IsDigit(phoneNumber[i]))
                    {
                        throw new Exception("\"Phone number\" - must be include only \"Digit\" character!");
                    }
                }
            }
            else
            {
                throw new Exception("String \"Length\" Error in \"First Name\" or/and \"Last Name\"!");
            }

            firstName = firstName.Remove(0, 1).Insert(0, firstName[0].ToString().ToUpper());
            lastName = lastName.Remove(0, 1).Insert(0, lastName[0].ToString().ToUpper());
        }
        private static void CheckEnteredPhoneNumberParameter(string phoneNumber)
        {
            if (phoneNumber.Length > 1)
            {
                if (phoneNumber[0] != '+')
                {
                    throw new Exception("\"Phone number\" - must be begin with the \'+\' character!");
                }
                for (int i = 1; i < phoneNumber.Length; i++)
                {
                    if (!char.IsDigit(phoneNumber[i]))
                    {
                        throw new Exception("\"Phone number\" - must be include only \"Digit\" character!");
                    }
                }
            }
            else
            {
                throw new Exception("ERROR: Phone number \"Length\" parametr must be >1 characters!");
            }
        }

        private static void ShowBinarySearchResult(string str, int _result)
        {
            if (_result == -1)
                Console.WriteLine("\"{0}\" element, not present", str);
            else
                Console.WriteLine("\"{0}\" element, found at index {1}", str, _result);
        }
        static int BinarySearchByLastName((string, string, string)[] phoneBook, String x)
        {
            int l = 0, r = phoneBook.Length - 1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;

                int res = x.CompareTo(phoneBook[m].Item1);

                // Check if x is present at mid
                if (res == 0)
                    return m;

                // If x greater, ignore left half
                if (res > 0)
                    l = m + 1;

                // If x is smaller, ignore right half
                else
                    r = m - 1;
            }

            return -1;
        }
        private static void SearchByName()
        {
            Console.Clear();
            Console.WriteLine("Search condition - if first/last name contains search term you will see it");

            Console.WriteLine("Enter Search Term...");
            var searchTerm = Console.ReadLine();

            try
            {
                CheckEnteredParameter(ref searchTerm);

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
                    throw new Exception("Not such users");
                }
            }
            catch (Exception ex)
            {
                ShowExeption(ex.Message, "");
            }
            Wait();
        }
        private static int SearchByFullName(ref string searchFirstName, ref string searchLastName, ref (string, string, string)[] PhoneBook)
        {

            CheckEnteredParameters(ref searchFirstName, ref searchLastName);

            int index = BinarySearchByLastName(PhoneBook, searchLastName);
            if (index != -1)
            {
                if (searchFirstName == PhoneBook[index].Item2)
                {
                    Console.WriteLine($"Found user {searchFirstName} {searchLastName} with phone {PhoneBook[index].Item3}");
                    index += 1;
                }
                else
                {
                    throw new Exception("The \"" + searchFirstName + " " + searchLastName + "\" user, not found!");
                }
            }

            return index;
        }
        private static void SearchByPhone()
        {
            Console.Clear();
            Console.WriteLine("Search condition - enter phone number");

            Console.WriteLine("Enter Search Phone number...");
            var searchPhone = Console.ReadLine();

            try
            {
                CheckEnteredPhoneNumberParameter(searchPhone);

                bool found = false;
                if (searchPhone.Length > 1)
                {
                    foreach (var (firstName, lastName, phoneNumber) in ReadPhoneBook())
                    {
                        if (phoneNumber.Contains(searchPhone, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"Found user {firstName} {lastName} with phone {phoneNumber}");
                            found = true;
                        }
                    }
                }
                if (!found)
                {
                    throw new Exception("Not such users");
                }
            }
            catch (Exception ex)
            {
                ShowExeption(ex.Message, "");
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

            string[] lines;
            (string, string, string)[] phoneBook;
            ReadPhoneBook(out lines, out phoneBook);
            (string, string, string) newElement = (lastName, firstName, phoneNumber);
            try
            {
                lines = AddNewElement(lines, phoneBook, ref newElement);
                File.WriteAllLines(Filename, lines);
            }
            catch (Exception ex)
            {
                ShowExeption(ex.Message);
            }
        }

        static void EditPhoneNumber()
        {
            Console.Clear();
            Console.WriteLine("Edit Phone number:");

            Console.WriteLine("Enter First Name...");
            var firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name...");
            var lastName = Console.ReadLine();

            string[] lines;
            (string, string, string)[] phoneBook;
            ReadPhoneBook(out lines, out phoneBook);

            try
            {
                int indexName = SearchByFullName(ref firstName, ref lastName, ref phoneBook);
                UpdateNewPhoneNumber(lastName, firstName, lines, indexName);
            }
            catch(Exception ex)
            {
                ShowExeption(ex.Message);
            }
        }
        private static void UpdateNewPhoneNumber(string? lastName, string? firstName, string[] lines, int indexName)
        {
            if ((indexName != -1) && (indexName <= lines.Length))
            {
                bool fileWritten = false;
                do
                {
                    Console.WriteLine("Enter New Phone Number...");
                    var phoneNumber = Console.ReadLine();
                    try
                    {
                        CheckEnteredPhoneNumberParameter(phoneNumber);
                        lines[indexName] = lastName + "," + firstName + "," + phoneNumber;
                        File.WriteAllLines(Filename, lines);
                        fileWritten = true;
                    }
                    catch (Exception ex)
                    {
                        ShowExeption(ex.Message, "Type \"Pnone number\" with \"{+123}\" format...");
                        Console.WriteLine("");
                    }
                } while (!fileWritten);
            }
            else
            {
                throw new Exception("ERORR: \"indexName\"!");
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
        private static void ShowExeption(string ex)
        {
            Console.WriteLine("\r\nExeption:");
            Console.WriteLine(ex);
            Console.WriteLine("Type \"Enter\" to continue...");
            Console.ReadLine();
        }
        private static void ShowExeption(string ex, string ToDo)
        {
            Console.WriteLine("\r\nExeption:");
            Console.WriteLine(ex);
            Console.WriteLine(ToDo);
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
        static (string, string, string)[] ReadPhoneBook(out string[] lines, out (string, string, string)[] phoneBook)
        {
            lines = File.ReadAllLines(Filename);

            phoneBook = new (string, string, string)[lines.Length - 1];
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

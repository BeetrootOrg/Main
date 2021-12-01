namespace ConsoleApp
{
    using System;
    class ConsoleApp
    {
        const string Filename = @"..\..\..\phonebook.csv";

        static void ShowCompareResult(bool result, string str1, string str2)
        {
            if (result == true)
            {
                Console.WriteLine("\"{0}\" == \"{1}\"", str1, str2);
            }
            else 
            { 
                Console.WriteLine("\"{0}\" != \"{1}\"", str1, str2);
            }
        }
        static bool Compare(string str1, string str2)
        {
            if(str1.Length != str2.Length)
            {
                return false;
            }
            for(int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    return false;
                }
            }
            return true;
        }
        static void ShowAnalizeResult(string str, (int, int, int)result)
        {
            Console.WriteLine("The string \"{0}\" consist: {1} Letters, {2} Digits and {3} another symbols", str, result.Item1, result.Item2, result.Item3);
        }
        static (int, int, int) Analize(string str)
        {
            int countAlphabetics = 0;
            int countDigits = 0;
            int countAnotherSymbols = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if(char.IsLetter(str[i]))
                {
                    countAlphabetics++;
                }
                else if(char.IsDigit(str[i]))
                {
                    countDigits++;
                }
                else
                {
                    countAnotherSymbols++;
                }

            }
            return (countAlphabetics, countDigits, countAnotherSymbols);
        }
        static void Sort(out string sortedString, string inputString)
        {
            inputString = inputString.ToLower();
            char[] arr = inputString.ToCharArray();
            Array.Sort(arr);
            sortedString = new string(arr);
        }
        static void ShowSortedString(string inputString, string sortedString)
        {
            Console.WriteLine("Input string: \"{0}\", Sorted string: \"{1}\"", inputString, sortedString);
        }
        static void Dublicate(out (char, int)[] dublicateChars, string inputString)
        {
            Sort(out inputString, inputString);
            int[] count = new int[inputString.Length];
            int charcount;
            int numberOfDublicats = 0;

            for (int i = 0; i < inputString.Length; i += charcount)
            {
                char checkChar = inputString[i];
                count[i] = 1;
                charcount = 1;
                if (char.IsLetter(checkChar))
                {
                    for (int j = i + 1; j < inputString.Length; j++)
                    {
                        if (checkChar == inputString[j])
                        {
                            count[i]++;
                            charcount++;
                        }
                    }
                }
                if (charcount > 1)
                {
                    numberOfDublicats++;
                }
            }
            dublicateChars = new (char, int)[numberOfDublicats];
            for (int i = 0, j = 0; i < count.Length; i++)
            {
                if (count[i] > 1)
                {
                    dublicateChars[j++] = (inputString[i], count[i]);
                }
            }
        }
        static void ShowDublicate(string inputString, (char, int)[] dublicateChars)
        {
            Console.WriteLine("The string \"{0}\", consist dublicat characters:", inputString);
            for(int i = 0; i < dublicateChars.Length; i++)
            {
                Console.WriteLine("{0} : {1}", dublicateChars[i].Item1, dublicateChars[i].Item2);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/homework/08-Text \r\n");


            Console.WriteLine("1. Compare:");
            string str1 = "string 1";
            string str2 = "string 2";
            bool result = Compare(str1, str2);
            ShowCompareResult(result, str1, str2);
            str1 = "same string";
            str2 = "same string";
            result = Compare(str1, str2);
            ShowCompareResult(result, str1, str2);
            Console.Write("\r\n");

            Console.WriteLine("2. Analize:");
            string analizeSting = "Hello!  %^& 234";
            (int, int, int) analizeResult = Analize(analizeSting);
            ShowAnalizeResult(analizeSting, analizeResult);
            Console.Write("\r\n");

            Console.WriteLine("3. Sort:");
            string nonSortedString = "Hello";
            string sortedString;
            Sort(out sortedString, nonSortedString);
            ShowSortedString(nonSortedString, sortedString);
            nonSortedString = "HklThRAfF";
            Sort(out sortedString, nonSortedString);
            ShowSortedString(nonSortedString, sortedString);
            Console.Write("\r\n");

            Console.WriteLine("4. Dublicate:");
            string inputString = "Hello and hi";
            (char, int)[] dublicateChars;
            Dublicate(out dublicateChars, inputString);
            ShowDublicate(inputString, dublicateChars);
            Console.Write("\r\n");

            while (true)
            {
                Menu();
            }

            Console.Write("\r\n");
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
        private static int SearchByFullName(string searchFirstName, string searchLastName)
        {
            int index = -1;
            bool found = false;

            foreach (var (firstName, lastName, phoneNumber) in ReadPhoneBook())
            {
                if (firstName.Contains(searchFirstName, StringComparison.OrdinalIgnoreCase) ||
                    lastName.Contains(searchLastName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Found user {firstName} {lastName} with phone {phoneNumber}");
                    found = true;
                }
                index++;
            }

            if (!found)
            {
                Console.WriteLine("The \"{0} {1}\" user, not found!", searchFirstName, searchLastName);
                return -1;
            }
            return index-1;
        }
        private static int SearchByFullName(string searchFirstName, string searchLastName, ref (string, string, string)[] PhoneBook)
        {
            int index = 1;
            bool found = false;

            foreach (var (firstName, lastName, phoneNumber) in PhoneBook)
            {
                if (firstName.Contains(searchFirstName, StringComparison.OrdinalIgnoreCase) ||
                    lastName.Contains(searchLastName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Found user {firstName} {lastName} with phone {phoneNumber}");
                    found = true;
                    break;
                }
                index++;
            }

            if (!found)
            {
                Console.WriteLine("The \"{0} {1}\" user, not found!", searchFirstName, searchLastName);
                return -1;
            }
            return index;
        }
        private static int SearchByFullName(string searchFirstName, string searchLastName, ref string[] lines)
        {
            int index = 0;
            bool found = false;

            foreach (var name in lines)
            {
                if (name.Contains(searchFirstName, StringComparison.OrdinalIgnoreCase) || name.Contains(searchLastName, StringComparison.OrdinalIgnoreCase))
                {
                    // Console.WriteLine($"Found user {firstName} {lastName} with phone {phoneNumber}");
                    Console.WriteLine("Found user {0}", name);
                    found = true;
                    break;
                }
                index++;
            }

            if (!found)
            {
                Console.WriteLine("The \"{0} {1}\" user, not found!", searchFirstName, searchLastName);
                return -1;
            }
            return index;
        }
        private static void SearchByPhone()
        {
            Console.Clear();
            Console.WriteLine("Search condition - enter phone number");

            Console.WriteLine("Enter Search Phone number...");
            var searchPhone = Console.ReadLine();

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

            int indexName = SearchByFullName(firstName, lastName, ref phoneBook);
            UpdateNewPhoneNumber(firstName, lastName, lines, indexName);
        }
        private static void UpdateNewPhoneNumber(string? firstName, string? lastName, string[] lines, int indexName)
        {
            if ((indexName != -1) && (indexName <= lines.Length))
            {
                Console.WriteLine("Enter New Phone Number...");
                var phoneNumber = Console.ReadLine();

                lines[indexName] = firstName + "," + lastName + "," + phoneNumber;
                File.WriteAllLines(Filename, lines);
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

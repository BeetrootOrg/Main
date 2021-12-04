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
            int charCount;
            int numberOfDublicats = 0;

            for (int i = 0; i < inputString.Length; i += charCount)
            {
                char checkChar = inputString[i];
                count[i] = 1;
                charCount = 1;
                if (char.IsLetter(checkChar))
                {
                    for (int j = i + 1; j < inputString.Length; j++)
                    {
                        if (checkChar == inputString[j])
                        {
                            count[i]++;
                            charCount++;
                        }
                    }
                }
                if (charCount > 1)
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
        class Person
        {
            public string Name { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string PhoneNumber { get; set; }
            public int Height { get; set; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/homework/08-Text \r\n");

            var person = new Person();
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

            String[] arr = { "contribute", "aaeks", "Aae", "yractice" };
            String x = "ide";
            int _result = binarySearch(arr, x);
            ShowBinarySearchResult(x, _result);

            string[] lines;
            (string tLastName, string tFirstName, string tPhoneNumber)[] phoneBook;
            ReadPhoneBook(out lines, out phoneBook);
            x = "Sidorov";
            _result = BinarySearchByLastName(phoneBook, x);
            ShowBinarySearchResult(x, _result);
            x = "Petrov";
            _result = BinarySearchByLastName(phoneBook, x);
            ShowBinarySearchResult(x, _result);
            x = "Misik";
            _result = BinarySearchByLastName(phoneBook, x);
            ShowBinarySearchResult(x, _result);
            x = "qwe";
            _result = BinarySearchByLastName(phoneBook, x);
            ShowBinarySearchResult(x, _result);
            x = "Ivanov";
            _result = BinarySearchByLastName(phoneBook, x);
            ShowBinarySearchResult(x, _result);

            Array.Sort(arr);


            Array.Sort(lines, 1, lines.Length-1);
            string temp = lines[1];
            lines[1] = lines[4];
            lines[4] = temp;
            Array.Sort(lines, 1, lines.Length - 1);

            try
            {
                (string tLastName, string tFirstName, string tPhoneNumber) newElement = ("Shewchenko", "Taras", "+4838");
                lines = AddNewElement(lines, phoneBook, newElement);
                newElement = ("Ivanov", "", "");
                lines = AddNewElement(lines, phoneBook, newElement);
            }
            catch (Exception ex)
            {
                ShowExeption(ex.Message);
            }

            while (true)
            {
                Menu();
            }

            Console.Write("\r\n");
        }
        static string[] AddNewElement(string[] array, (string, string, string)[] phoneBook, (string lastName, string firstName, string phoneNumber) newElement)
        {
            CheckEnteredParameters(newElement.firstName, newElement.lastName, newElement.phoneNumber);

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
        private static void CheckEnteredParameters(string firstName, string lastName)
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
        }
        private static void CheckEnteredParameters(string firstName, string lastName, string phoneNumber)
        {
            if ((firstName.Length > 0) || (lastName.Length > 0))
            {
                if (!char.IsLetter(firstName[0]) || !char.IsLetter(lastName[0]))
                {
                    throw new Exception("\"First Name\" or/and \"Last Name\" - must be begin with the \"Letter\" character!");
                }
                if(phoneNumber[0] != '+')
                {
                    throw new Exception("\"Phone number\" - must be begin with the \'+\' character!");
                }
                for(int i = 1; i < phoneNumber.Length; i++)
                {
                    if(!char.IsDigit(phoneNumber[i]))
                    {
                        throw new Exception("\"Phone number\" - must be include only \"Digit\" character!");
                    }
                }
            }
            else
            {
                throw new Exception("String \"Length\" Error in \"First Name\" or/and \"Last Name\"!");
            }
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
        static int binarySearch(String[] arr, String x)
        {
            int l = 0, r = arr.Length - 1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;

                int res = x.CompareTo(arr[m]);

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

            //if((searchFirstName.Length > 0) || (searchLastName.Length > 0))
            //{
            //    if (!char.IsLetter(searchFirstName[0]) || !char.IsLetter(searchLastName[0]))
            //    {
            //        throw new Exception("\"First Name\" or/and \"Last Name\" - must be begin with the \"Letter\" character!");
            //    }
            //}
            //else
            //{
            //    throw new Exception("String \"Length\" Error in \"First Name\" or/and \"Last Name\"!");
            //}

            CheckEnteredParameters(searchFirstName, searchLastName);

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
                throw new Exception("The \"" + searchFirstName + " " + searchLastName + "\" user, not found!");
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
        private string value;
        private int count;
        private Tree left;
        private Tree right;
        enum Tree
        {
            left,
            Right,
        };

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
                lines = AddNewElement(lines, phoneBook, newElement);
                File.WriteAllLines(Filename, lines);
            }
            catch (Exception ex)
            {
                ShowExeption(ex.Message);
            }

            /*Replace this lineFile.AppendAllLines(Filename, new[] { $"{lastName},{firstName},{phoneNumber}" });*/
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
                int indexName = SearchByFullName(lastName, firstName, ref phoneBook);
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

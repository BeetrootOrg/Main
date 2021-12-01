namespace ConsoleApp
{
    using System;
    class ConsoleApp
    {
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
            Console.WriteLine("\r\n a.tkachenko/homework/07-strings \r\n");


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

            Console.Write("\r\n");
        }
    }
}

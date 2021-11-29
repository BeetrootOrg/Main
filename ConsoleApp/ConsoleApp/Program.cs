using System;
namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            string str1 = "TestD";
            string str2 = "Testd";
            Console.WriteLine("Compare Method");
            Console.WriteLine(Compare(str1, str2));
            Console.WriteLine("Analyze Method");
            Console.WriteLine(Analyze("Test string 12345 ???@"));
            Console.WriteLine("Sort Method");
            Console.WriteLine(Sort("vbfhavkcjcdj"));
            Console.WriteLine("Duplicate Method");
            foreach (char str in Duplicate("AaaaazzzzSFsAA"))
            {
                Console.WriteLine(str);
            }
        }

        //Compare method
        static bool Compare(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < str1.Length; i++)
                    if (str1[i] != str2[i])
                        return false;
                return true;
            }
        }

        //Analyze method
        static string Analyze(string str)
        {
            int alphabeticChars = 0;
            int digits = 0;
            int specialSymbols = 0;

            foreach (var item in str)
            {
                if (Char.IsDigit(item))
                {
                    digits++;
                }
                else if (Char.IsLetter(item))
                {
                    alphabeticChars++;
                }
                else
                {
                    specialSymbols++;
                }
            }
            string result = $"There are {alphabeticChars} - alpabetical chars, {digits} - digits and {specialSymbols} - special symbols (spaces are included) in this string";
            return result;
        }

        //Sort method
        static string Sort(string str)
        {
            char[] loweredCharArr = str.ToLower().ToCharArray();

            for (int i = 0; i < loweredCharArr.Length - 1; i++)
                for (int j = 0; j < loweredCharArr.Length - i - 1; j++)
                    if (loweredCharArr[j] > loweredCharArr[j + 1])
                    {
                        char temp = loweredCharArr[j];
                        loweredCharArr[j] = loweredCharArr[j + 1];
                        loweredCharArr[j + 1] = temp;
                    }
            return new string(loweredCharArr);
        }

        //Duplicate method
        static char[] Duplicate(string str)
        {
            string preResult = "";
            string result = "";
            string loweredStr = str.ToLower();
            foreach (char value in loweredStr)
            {
                if (preResult.IndexOf(value) == -1)
                {
                    preResult += value;
                    result += value;
                }
            }
            return result.ToCharArray();
        }
    }
}
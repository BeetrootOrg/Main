using System;
using System.Diagnostics;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            string strA = "ABC";
            string strB = "  ^hEL  LOhe^ll9o8";

            Console.WriteLine($"Equals {strA} & {strB}: {StringCompare(strA, strB)}");

            Console.WriteLine(SortString(strB) + "\n");

            Console.WriteLine(strB);
            StringAnalyze(strB, out int letterCount, out int numberCount, out int spchCount);
            Console.WriteLine($"Numbers of letters in string: {letterCount}");
            Console.WriteLine($"Numbers of digits in string: {numberCount}");
            Console.WriteLine($"Number of special character: {spchCount}");
        }

        static bool StringCompare(string a, string b)
        {
            if(a == b)
            {
                return true;
            }
            return false;
        }

        //Bubble Sort for string
        static string SortString(string str)
        {
            //Delete all spaces in string and change to lower register
            char[] strCopy = str.Replace(" ", "").ToLower().ToCharArray();

            for (int i = 0; i < strCopy.Length; i++)
            {
                for (int j = 0; j < strCopy.Length - 1 - i; j++)
                {
                    if (strCopy[j] > strCopy[j + 1])
                    {
                        char temp = strCopy[j + 1];
                        strCopy[j + 1] = strCopy[j];
                        strCopy[j] = temp;
                    }
                }
            }
            return String.Join("", strCopy);
        }

        static void StringAnalyze(string str, out int letterCount, out int numberCount, out int spchCount)
        {
            char[] strCopy = str.Replace(" ", "").ToCharArray();

            letterCount = 0;
            numberCount = 0;
            spchCount = 0;

            for (int i = 0; i < strCopy.Length; i++)
            {
                if(Char.IsLetter(strCopy[i]))
                {
                    letterCount++;
                }
                else if(Char.IsDigit(strCopy[i]))
                {
                    numberCount++;
                }
                else spchCount++;
            }
        }

        static char[] Duplicate(string str)
        {
            char[] strCopy = str.Replace(" ", "").ToLower().ToCharArray();

        }
    }
}
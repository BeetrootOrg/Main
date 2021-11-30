using System;
using System.Diagnostics;
using System.Text;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            //Test method StringCompare
            string strA = "ABC";
            string strB = "ABc";

            Console.WriteLine($"Equals {strA} & {strB}: {StringCompare(strA, strB)} \n");

            //Test method SortString
            string toSortStr = "zvxbdusydsdaa";
            Console.WriteLine($"Unsorted string: {toSortStr}");
            Console.WriteLine(($"Sorted string: {SortString(toSortStr)}\n"));

            //Test Analyze string method
            string toAnalizeStr = "2+2=x and";
            Console.WriteLine($"String to analyze: {toAnalizeStr}");
            StringAnalyze(toAnalizeStr, out int letterCount, out int numberCount, out int spchCount);
            Console.WriteLine($"Numbers of letters in string: {letterCount}");
            Console.WriteLine($"Numbers of digits in string: {numberCount}");
            Console.WriteLine($"Number of special character: {spchCount}\n");

            //Test Duplicate check
            string checkDupStr = "Hello && Hill";
            Console.WriteLine($"Check duolicate: {checkDupStr}");

            foreach (char item in Duplicate(checkDupStr))
            {
                Console.Write(item + " ");
            }
        }


        //Compare Two strings
        static bool StringCompare(string a, string b) => a == b;

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

        //Method to Analyze string
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

        //Method to Check Duplicate Letters
        //It was hardest
        static char[] Duplicate(string str)
        {
            char[] strArray = str.Replace(" ", "").ToLower().ToCharArray();
            StringBuilder strCopy = new StringBuilder(str.Replace(" ", "").ToLower());
            StringBuilder result = new StringBuilder();


            //We checking how many same letters we removed
            for (int i = 0; i < strArray.Length; i++)
            {
                int currentLenght = strCopy.Length;

                if(currentLenght - strCopy.Replace(strArray[i].ToString(), "").Length > 1)
                {
                    result.Append(strArray[i]);
                }
            }
            return result.ToString().ToCharArray();
        }
    }
}
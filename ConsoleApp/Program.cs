using System;

namespace ConsoleApp
{

    class Program
    {
        static void Main()
        {
            /*1. Compare that will return true if 2 strings are equal, otherwise false, but do not use build -in method
            2. Analyze that will return number of alphabetic chars in string, digits and another special characters
            3. Sort that will return string that contains all characters from input string sorted in alphabetical order(e.g. 'Hello'-> 'ehllo')
            4. Duplicate that will return array of characters that are duplicated in input string(e.g. 'Hello and hi'-> ['h', 'l'])
            */

            string str1 = "Abcde";
            string str2 = "abcde";
            string formatted = "1. Comparing strings: {0} and {1}. Result is {2}.\n";
            Console.WriteLine(formatted,str1,str2,Compare(str1,str2));

            string str3 = "123Asdvsd!$%^";

            Console.WriteLine($"2. Analysing string {str3} for numbers types of symbols");
            Analyse(str3);

            string str4 = "Hello how are you";
            formatted = "3. Sort some random string:\n {0}.\n Get all symbols in alphabetical order:\n{1}\n.";
            Console.WriteLine(formatted,str4, SortCharInString(str4));

            string str5 ="1.some test string with some words 1 and 2";

            

            Console.WriteLine($"4.Analyse random string:\n {str5}.\n Found next dublicated symbols:");
            Duplicate(str5);

            static void Duplicate(string str)
            {
                bool triple;
                int j = 0;
                char [] array= new char[str.Length-1];
                for (int i = 0; i < str.Length - 1; i++)
                {
                    //Console.WriteLine(str[i]);

                    if ((str.IndexOf(str[i],i+1)!=-1)&& (Char.IsWhiteSpace(str[i])==false))
                    {
                        //Console.WriteLine($"duplicate: {str[i]} on positon {i} and {str.IndexOf(str[i], i + 1)}");
                        triple = false;
                        for (int h = 0; h < array.Length - 1; h++)
                        {
                            if (str[i] == array[h])
                                triple = true;
                        }
                        if (triple == false)
                        {
                            array[j] = str[i];
                            j++;
                        }
                    }
                }
                //string str = string.Join(", ", array);
                Array.Resize(ref array, j);
                PrintArray(array);
                //Console.WriteLine("array of duplicate");
                

            }
            static void PrintArray(char[] arr)
            {
                string str=string.Join(", ", arr);
                str =str.TrimEnd(',');
                Console.WriteLine(str);
            }


            static string SortCharInString(string str)
            { 
            char[] array = new char [str.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = Char.ToLower(str[i]);
                }
                //Array.Sort(array); =)
                for (int j = str.Length; j > 0; j--)
                {
                    char tempChar;
                    for (int i = 0; i < j-1; i++)
                    {
                        if (array[i] > array[i + 1])
                        {
                            tempChar = array[i];
                            array[i] = array[i + 1];
                            array[i + 1] = tempChar;
                        }
                    }
                }

                return new string(array);
            }

            static bool Compare(string first, string second)
            {
                if (first.Length != second.Length)
                    return false;
                else
                {
                    for (int i = 0; i < first.Length; ++i)
                    {
                        char a = first[i];
                        char b = second[i];
                        if (a != b)
                            return false;
                    }
                    return true;
                }
            }

            static void Analyse(string str)
            {
                int digits=0;
                int letter = 0;
                int symbol = 0;

                for (int i = 0; i < str.Length; i++)
                {
                    char c = str[i];
                    if (Char.IsDigit(c)) digits += 1;
                    if (Char.IsLetter(c)) letter += 1;
                    if (Char.IsSymbol(c)) symbol += 1;
                }
                Console.WriteLine($"Result of analyse: digits:{digits}, letters: {letter}, symbols: {symbol}\n");
            }
        }
    }
}
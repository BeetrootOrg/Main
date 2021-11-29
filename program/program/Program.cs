﻿using System;
namespace  ConsoleApp
{
    class Program
    {
        static void Main()
        {

            //First task
            Console.WriteLine("First task:");
            string stringCompare1 = "Hello";
            string stringCompare2 = "Hello";
            string sortABC = "Hello";
            string dublicate = "Hello and hi";




            bool compare = stringCompare1==stringCompare2;
            Console.WriteLine($"Is string equal: {compare}");

            //Second task
            Console.WriteLine("\nSecond task:");

            string example1 = "afASDsd12345";                  
            

            Console.Write("numbers = ");
            Console.WriteLine(CountOfNumbers(example1));
            Console.Write("letter = ");
            Console.WriteLine(CountOfLetters(example1));

            //Third task
            Console.WriteLine(SortByAlphabetical(sortABC));

            //Fourth task

            Console.WriteLine(DublicateFilter(dublicate));

        }

        static int CountOfLetters(String example1)
        {
            int letter = 0;

            for (int i = 0; i < example1.Length; i++)
            {
                if ((example1[i] >= 'A' && example1[i] <= 'Z') || (example1[i] >= 'a' && example1[i] <= 'z'))
                    letter++;
                
            }
            return letter;
        }

        static int CountOfNumbers(string example1)
        {
            int number = 0; 
            for(int i = 0; i < example1.Length; i++)
            {
                if (example1[i] >= '0' && example1[i] <= '9')
                    number++;
            }
            return number;
        }

        //Third task

        static string SortByAlphabetical(string input)
        {
            string charsLow = input.ToLower();
            char[] chars = charsLow.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }

        //Fourth task

        static string DublicateFilter(string input2)
        {
            {
                string table = "";
                int pos = 0;
                foreach (var character in input2.ToCharArray())
                {
                    pos = table.IndexOf(character, Math.Abs(pos));
                    if (pos == -1)
                    {
                        table += character;
                    }

                }
                return table;
            }
        }
        
    }
}
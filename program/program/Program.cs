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

            

            bool compare = stringCompare1==stringCompare2;
            Console.WriteLine($"Is string equal: {compare}");

            //Second task
            Console.WriteLine("\nSecond task:");

            string example1 = "afASDsd12345";                  
            

            Console.Write("numbers = ");
            Console.WriteLine(CountOfNumbers(example1));
            Console.Write("letter = ");
            Console.WriteLine(CountOfLetters(example1));
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

        
    }
}
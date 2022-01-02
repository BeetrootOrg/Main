using System;

namespace ConsoleApp
{
    static class StringExtencions
    {
        public static int CountWords(this string str) => string.IsNullOrEmpty(str) ? 0 : str.Split(' ').Length;
    }

    public class Program
    {
        static void Main()
        {
            Console.WriteLine("This is a string".CountWords());
            Console.WriteLine("Word".CountWords());
            Console.WriteLine(((string)null).CountWords());
        }
    }
}
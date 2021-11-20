using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            double result = FuncWithABigName(5.5);
            Console.WriteLine(result);
            Concat("Hello", "Dima");

            int ai = 0;
            Increment(ai);
            Console.WriteLine($"In Main: {ai}");

            IncrementRef(ref ai);
            Console.WriteLine($"In Main: {ai}");

            string str = "Hello";
            Add(str, ", Dima");
            Console.WriteLine($"In Main: {str}");

            AddRef(ref str, ", Dima");
            Console.WriteLine($"In Main: {str}");
        }

        static double FuncWithABigName(double x) => x * x * x + 5 * x * x + 6;
        static void Concat(string str1, string str2) => Console.WriteLine($"{str1}, {str2}");

        static void Increment(int i)
        {
            ++i;
            Console.WriteLine($"In Increment: {i}");
        }

        static void IncrementRef(ref int i)
        {
            ++i;
            Console.WriteLine($"In IncrementRef: {i}");
        }

        static void Add(string str1, string str2)
        {
            str1 += str2;
            Console.WriteLine($"In Add: {str1}");
        }

        static void AddRef(ref string str1, string str2)
        {
            str1 += str2;
            Console.WriteLine($"In AddRef: {str1}");
        }

        static int AddIfOdd(int i1, int i2) => i1 % 2 == 0 && i2 % 2 == 0
            ? i1 + i2
            : 0;
    }
}
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

            ai = 0;
            IncrementRef(ref ai);
            Console.WriteLine($"In Main: {ai}");
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
    }
}
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
        }

        static double FuncWithABigName(double x) => x * x * x + 5 * x * x + 6;
        static void Concat(string str1, string str2) => Console.WriteLine($"{str1}, {str2}");
    }
}
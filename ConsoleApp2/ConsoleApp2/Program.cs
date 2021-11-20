using System;
namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            double result = FuncWithBigName(5.5);
            Console.WriteLine(result);
            Concat("Hello", "Dima");
        }

        static double FuncWithBigName(double x) {
            return x * x * x + 5 * x * x + 6;
        }

        // => FuncWithBigName(double x) =>  x * x * x + 5 * x * x + 6;

        static void Concat(string str1, string str2) => Console.WriteLine($"{str1}, {str2}");

    }
}

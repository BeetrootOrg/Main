using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            double result = FuncWithABigName(5.5);
            Console.WriteLine(result);
        }

        static double FuncWithABigName(double x) => x * x * x + 5 * x * x + 6;
    }
}
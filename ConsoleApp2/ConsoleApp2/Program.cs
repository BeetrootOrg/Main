using System;
namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            double result = FuncWithBigName(5.5);
            Console.WriteLine(result);
        }

        static double FuncWithBigName(double x) {
            return x * x * x + 5 * x * x + 6;
        }
    }
}

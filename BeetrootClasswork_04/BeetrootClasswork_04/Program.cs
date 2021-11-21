// See https://aka.ms/new-console-template for more information
using System;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            /*
            int n = 20;
            int sum = 0;
            int x0 = 0;
            int x1 = 1111;

            Console.WriteLine(x0);
            Console.WriteLine(x1);

            for (int i = 0; i < n - 2; i++)
            {
                sum = x0 + x1;
                x0 = x1;
                x1 = sum;
                Console.WriteLine(sum);
            }
            Console.WriteLine($"{x1} / {x0} = {(double)x1 / (double)x0}");
            */

            double result = FunkWithABigName(5.5);
            Console.WriteLine($"F(5.5) = {result}");
        }
        static double FunkWithABigName(double x) => x * x * x + 5 * x * x + 6;
        
    }
}
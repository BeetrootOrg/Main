using System;

namespace ConsoleApp
{

    class Program
    {
        static void Main()
        { 
            Console.WriteLine($"Max and Min numbers: {FindMax(-1, 2, 0, 462647643)}, {FindMin(-1, 2, 0, 462647643)}\n");

            double multiply;
            if (TryMulIfDividedByTgree(3, 1, out multiply))
            {
                Console.WriteLine($"Multiply: {multiply}\n");
            }
            else
            {
                Console.WriteLine($"Multiply error: {multiply}\n");
            }
            Console.WriteLine($"Str task: {Repeat("str", 0)}");
        }
        static int FindMin(int a, int b = 2147483647, int c = 2147483647, int d = 2147483647, int e = 2147483647)
        {
            return (Math.Min(Math.Min(Math.Min(Math.Min(a, b), c), d), e));
        }
        static int FindMax(int a, int b, int c = -2147483648, int d = -2147483648, int e = -2147483648)
        {
            return (Math.Max(Math.Max(Math.Max(Math.Max(a, b), c), d), e));
        }
        static bool TryMulIfDividedByTgree(int a, int b, out double multiply)
        {
            if (a%3 == 0 || b%3 == 0)
            {
                multiply = a*b;
                return true;
            }
            else
            {
                multiply = 0;
                return false;
            }
        }
        static string Repeat(string str, int n)
        {
            if (n>0)
            {
                for (int a= 2; a <= n; ++a)
                {
                    str += str;
                }
                return str;
            }
            return "Something went wrong with string, please fix the problem";
        }
    }

}
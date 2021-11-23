// See https://aka.ms/new-console-template for more information

using System;

namespace NewConsole
{
    class Program
    {
        static void Main()
        {
            //Test MaxNumber
            Console.WriteLine(MaxNumber(2, 3, 9, 0, -9));

            //Test MinNumber
            Console.WriteLine(MinNumber(2, 3, 9, 0, -9));

            //Test TryMulIfDividedByThree
            int mul;
            const int a = 3;
            const int b = 99;

            if(TryMulIfDividedByThree(a, b, out mul))
            {
                Console.WriteLine($"{a} * {b} = {mul}");
            }
            else
            {
                Console.WriteLine("This numbers or one of them, NOT divided by three!");
            }

            //Test Repeat
            Console.WriteLine(Repeat("Dima ",3));

        }

        static int MaxNumber(int a, int b, int c = int.MinValue, int d = int.MinValue, int e = int.MinValue)
        {
            if (a > b && a > c && a > d && a > e)
            {
                return a;
            }
            else if (b > c && b > d && b > e)
            {
                return b;
            }
            else if (c > d && c > e)
            {
                return c;
            }
            else if (d > e)
            {
                return d;
            }
            else return e;
        }

        static int MinNumber(int a, int b, int c = int.MaxValue, int d = int.MaxValue, int e = int.MaxValue)
        {
            if (a < b && a < c && a < d && a < e)
            {
                return a;
            }
            else if (b < c && b < d && b < e)
            {
                return b;
            }
            else if (c < d && c < e)
            {
                return c;
            }
            else if (d < e)
            {
                return d;
            }
            else return e;
        }

        static bool TryMulIfDividedByThree(int a, int b, out int mul)
        {
            if (a % 3 == 0 && b % 3 == 0)
            {
                mul = a * b;
                return true;
            }
            else
            {
                mul = 0;
                return false;
            }
        }

        static string Repeat(string str, int n)
        {
            if (n > 1)
            {
                str += Repeat(str, n - 1); 
            }
            return str;
        }
    }
}

// See https://aka.ms/new-console-template for more information

using System;

namespace BeetrootHomework_04
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine($"Max number: {MaxNumber(20, 5, -2, 2, 0)}");
            Console.WriteLine($"Min number: {MinNumber(20, 5, -2, 2, 0)}");

            int a = 0;
            int b = 0;
            int mul = 0;

            if(TryMulIfDividedByThree(a, b, out mul))
            {
                Console.WriteLine($"{a} * {b} = {mul}");
            }
            else
            {
                Console.WriteLine("This numbers not divided by three.");
            }
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
            if (a != 0 && b != 0)
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
            else
            {
                mul = 0;
                return false;
            }
        }
    }
}
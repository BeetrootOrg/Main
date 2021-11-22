using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(RoundToNext5(0));
            Console.WriteLine(RoundToNext5(1));
            Console.WriteLine(RoundToNext5(5));
            Console.WriteLine(RoundToNext5(6));
            Console.WriteLine(RoundToNext5(10));

            Console.WriteLine(Gcd(30, 12));
            Console.WriteLine(Gcd(100, 100));
            Console.WriteLine(Gcd(8, 9));
            Console.WriteLine(Gcd(1, 1));
        }

        static int RoundToNext5(int n) => ((n / 5) + 1) * 5;

        static int Gcd(int a, int b)
        {
            for (int i = Math.Min(a, b); i > 1; --i)
            {
                if (a % i == 0 && b % i == 0)
                {
                    return i;
                }
            }

            return 1;
        }
    }
}
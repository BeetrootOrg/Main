using System;

namespace ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            int a, b, c;
            Console.WriteLine("Enter the a: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(RoundToNext5(a));

            Console.WriteLine("Enter the b and c: ");
            b = Convert.ToInt32(Console.ReadLine());
            c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Gcd(b, c));

        }

        static int RoundToNext5(int n)
        {
            n = n - n % 5 + 5;
            return n;
        }

        static int Gcd(int a, int b)
        {
            int c = 0;
            for (int i = 1; i < Math.Max(a, b); i++)
            {
                if (a % i == 0 && b % i == 0) { c = i; }
            }
            return c;
        }
    }
}

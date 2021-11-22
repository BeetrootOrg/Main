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
            for (int i = Math.Min(a, b); i > 0; i--) 
            {
                if (a % i == 0 && b % i == 0) { return i; }
            }
            return 0;
        }
    }
}

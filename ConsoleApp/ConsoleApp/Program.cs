using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Factorial(0));
            Console.WriteLine(Factorial(1));
            Console.WriteLine(Factorial(5)); // 120
            Console.WriteLine(Factorial(10)); // 3628800

            Console.WriteLine(Gcd(100, 10)); // 10
            Console.WriteLine(Gcd(30, 12)); // 6
            Console.WriteLine(Gcd(12, 30)); // 6
            Console.WriteLine(Gcd(8, 9)); // 1
            Console.WriteLine(Gcd(1, 1)); // 1
        }

        // 0! = 1
        // 1! = 1
        // n! = 1 * 2 * 3 * ... * n
        // n! = n * (n - 1) * (n - 2) * ... 2 * 1
        // (n - 1)! = (n - 1) * (n - 2) * ... 2 * 1
        // n! = n * (n - 1)!
        static long Factorial(int n) => n == 0 ? 1 : n * Factorial(n - 1);

        static int Gcd(int a, int b) => Gcd(a, b, Math.Min(a, b));

        static int Gcd(int a, int b, int possibleGcd) => a % possibleGcd == 0 && b % possibleGcd == 0
                ? possibleGcd
                : Gcd(a, b, possibleGcd - 1);
    }
}
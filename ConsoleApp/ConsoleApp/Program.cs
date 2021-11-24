using System;

namespace ConsoleApp
{
    class Program
    {
        static long Func1(int n)
        {
            return n == 0 ? 1 : n * Func1(n - 1);
        }
        static int Gcd(int a, int b)
        {
            return Gcd(a, b, Math.Min(a, b));
        }
        static int Gcd(int a, int b,int possibleGcd)
        {
            return a % possibleGcd == 0 && b % possibleGcd == 0 ? possibleGcd : Gcd(a, b, possibleGcd - 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the nubmer n : ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Factorial {n} = {Func1(n)}");

            Console.WriteLine("Enter the nubmers a, b : ");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Gcd( {a},{b}) = {Gcd(a, b)}");
        }

    }
}

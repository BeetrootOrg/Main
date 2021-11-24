using System;



namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Fact(0));
            Console.WriteLine(Fact(1));
            Console.WriteLine(Fact(5));
            Console.WriteLine(Fact(10));
            Console.WriteLine(Gcd(100, 10));
            Console.WriteLine(Gcd(30, 12));
        }
        //N! = N * (N-1)!
        //1.факторіал числа N використовуючи рекурсію, де N! = 1*2*3*...*N, наприклад, 1 -> 1; 2-> 2; 3-> 6
        static long Fact(int n) => n == 0 ? 1 : n * Fact(n - 1);

        // 2. найбільший спільний дільник для a & b використовуючи рекурсію, наприклад, (30, 12) -> 6; (8, 9) -> 1, (1, 1) -> 1
        static int Gcd(int a, int b) => Gcd(a, b, Math.Min(a, b));
        static int Gcd(int a, int b, int possibleGcd) => a % possibleGcd == 0 && b % possibleGcd == 0 ? possibleGcd : Gcd(a, b, possibleGcd - 1);

    }
}
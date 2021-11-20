using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            double result = FuncWithABigName(5.5);
            Console.WriteLine(result);
            Concat("Hello", "Dima");

            int ai = 0;
            Increment(ai);
            Console.WriteLine($"In Main: {ai}");

            IncrementRef(ref ai);
            Console.WriteLine($"In Main: {ai}");

            string str = "Hello";
            Add(str, ", Dima");
            Console.WriteLine($"In Main: {str}");

            AddRef(ref str, ", Dima");
            Console.WriteLine($"In Main: {str}");

            Console.WriteLine(AddIfOdd(2, 4));
            Console.WriteLine(AddIfOdd(1, 4));
            Console.WriteLine(AddIfOdd(2, 1));

            Console.WriteLine(AddIfOdd(-2, 2));
            Console.WriteLine(AddIfOdd(-1, 1));
            Console.WriteLine(AddIfOdd(0, 0));

            const int i1 = 3;
            const int i2 = 4;

            int sum;
            if (TryAddIfOdd(i1, i2, out sum))
            {
                Console.WriteLine($"Sum equal to {sum}");
            }
            else
            {
                Console.WriteLine("Cannot count sum because inputs are not odd");
            }

            // int.TryParse("1", out int res);
            Console.WriteLine(SomeMath(5));
            Console.WriteLine(SomeMath(5, 4));
            Console.WriteLine(SomeMath(5, 4, 6));
            Console.WriteLine(SomeMath(5, 4, 6, 1));
        }

        static double FuncWithABigName(double x) => x * x * x + 5 * x * x + 6;
        static void Concat(string str1, string str2) => Console.WriteLine($"{str1}, {str2}");

        static void Increment(int i)
        {
            ++i;
            Console.WriteLine($"In Increment: {i}");
        }

        static void IncrementRef(ref int i)
        {
            ++i;
            Console.WriteLine($"In IncrementRef: {i}");
        }

        static void Add(string str1, string str2)
        {
            str1 += str2;
            Console.WriteLine($"In Add: {str1}");
        }

        static void AddRef(ref string str1, string str2)
        {
            str1 += str2;
            Console.WriteLine($"In AddRef: {str1}");
        }

        static int AddIfOdd(int i1, int i2) => i1 % 2 == 0 && i2 % 2 == 0
            ? i1 + i2
            : 0;

        static bool TryAddIfOdd(int i1, int i2, out int sum)
        {
            if (i1 % 2 == 0 && i2 % 2 == 0)
            {
                sum = i1 + i2;
                return true;
            }

            sum = 0;
            return false;
        }

        static int SomeMath(int a, int b = 3) => a + b;
        static int SomeMath(int a, int b, int c = 4) => a * 2 + b * 3 + c * 5;
        static double SomeMath(int a, int b, int c = 4, int d = 5) => Math.Sqrt(a + b + c + d);
    }
}
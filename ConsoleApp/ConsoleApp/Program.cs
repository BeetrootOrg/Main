using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            double result = FuncWithABigName(5.5);
            Console.WriteLine($"Result: {result}");
            Concat("Hi", "Sasha");

            int ai = 0;
            Increment(ai);
            Console.WriteLine($"In Main:{ai}");

            ai = 0;
            IncrementRef(ref ai);
            Console.WriteLine($"In Main:{ai}");

            string str = "Hello";
            Add(str, ", Sasha");
            Console.WriteLine($"In Main:{str}");

            str = "Hello";
            AddRef(ref str, ", Sasha");
            Console.WriteLine($"In Main:{str}");


            Console.WriteLine(AddIffEven(4, 10));

            const int i1 = 2;
            const int i2 = 11;
            int sum;
            if (TryAddIfEven(i1, i2, out sum))
            {
                Console.WriteLine($"Sum equal to {sum}");
            }
            else
            {
                Console.WriteLine($"Can't count sum because inputs are not even");
            }

            Console.WriteLine(SomeMath(5));
            Console.WriteLine(SomeMath(5, 4));
            Console.WriteLine(SomeMath(5, 4, 6));
            Console.WriteLine(SomeMath(5.0, 4, 6));
            Console.WriteLine(SomeMath(5, 4, 6, 20));
            Console.WriteLine(SomeMath(b: 5, a: 4));

            Console.WriteLine("SUM");
            Console.WriteLine(Sum(1, 5));
            Console.WriteLine(Sum(3, 1));
            Console.WriteLine(Sum(1, 1));


            Console.WriteLine(Fbnc(4));
        }

        static double FuncWithABigName(double x) => x * x * x + 5 * x * x + 6;

        static void Concat(string str1, string str2) => Console.WriteLine($"{str1}, {str2}");

        static void IncrementRef(ref int i)
        {
            ++i;
            Console.WriteLine($"In Increment: {i}");
        }

        static void Increment(int i)
        {
            ++i;
            Console.WriteLine($"In Increment: {i}");
        }

        static void Add(string str1, string str2)
        {
            str1 += str2;
            Console.WriteLine($"In Add: {str1}");
        }

        static void AddRef(ref string str1, string str2)
        {
            str1 += str2;
            Console.WriteLine($"In Add: {str1}");
        }

        static int AddIffEven(int i1, int i2) => i1 % 2 == 0 && i2 % 2 == 0 ? i1 + i2 : 0;


        static bool TryAddIfEven(int i1, int i2, out int sum)
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
        static int SomeMath(int a, int b, int c = 3) => a + b + c;
        static double SomeMath(double a, int b, int c = 3) => a + b + c;
        static double SomeMath(int a, int b, int c = 3, int d = 10) => Math.Sqrt(a + b + c + d);

        static int Sum(int from, int to)
        {
            if (from > to) return Sum(to, from);
            if (from == to) return from;
            return from + Sum(from + 1, to);

        }

        static int Fbnc(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fbnc(n - 1) + Fbnc(n - 2);
        }
    }
}
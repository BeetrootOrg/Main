using System;

namespace ConsoleApp
{

    class Program
    {
        static void Main()
        {
            double result = FunctWihABigName(5.5);
            Console.WriteLine(result);
            Concat("Hello", "Test");

            int ai = 0;
            Increment(ai);

            IncrementRef(ref ai);
            Console.WriteLine($"In Main: {ai}");

            string str = "Hello";
            Add(str, ",Test");
            Console.WriteLine($"In main {str}");

            AddRef(ref str, ",Test");
            Console.WriteLine($"In main {str}");

            Console.WriteLine(ADdIfOdd(-2,2));
            Console.WriteLine(ADdIfOdd(1, 4));
            Console.WriteLine(ADdIfOdd(-2, 2));
            Console.WriteLine(ADdIfOdd(0, 0));

            const int i1 = 3;
            const int i2 = 4;

            int sum;
            if (TryAddifOdd(i1, i2, out sum))
            {
                Console.WriteLine($"Sum equal to {sum}");
            }
            else 
            {
                Console.WriteLine($"Cannot count sum cause inputs not odd");
            }
        }

        static double FunctWihABigName(double x) => x * x * x + 5 * 5 * 5 + 6;

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
            Console.WriteLine($"int Add: {str1}");

        }
        static void AddRef(ref string str1, string str2)
        {
            str1 += str2;
            Console.WriteLine($"int AddRef: {str1}");

        }

        static int ADdIfOdd(int i1, int i2) => i1 % 2 == 0 && i2 % 2 == 0
            ? i1 + i2
            : 0;

        static bool TryAddifOdd(int i1, int i2, out int sum)
        {
            if (i1 % 2 == 0 && i2 % 2 == 0)
            {
                sum = i1 + i2;
                return true;
            }
            sum = 0;
            return false;
        }

    }
    }


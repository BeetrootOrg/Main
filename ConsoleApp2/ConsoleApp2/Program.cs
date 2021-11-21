using System;
namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            double result = FuncWithBigName(5.5);
            Console.WriteLine(result);
            Concat("Hello", "Dima");

            int ai = 0;
            IncrementRef(ref ai);
            Console.WriteLine($"In Increment {ai}");

            string str = "Hello";
                Add(str, ", Dima");
            Console.WriteLine($"In Man {str}");

            AddRef(ref str, ", Dima");
            Console.WriteLine($"In Man ref {str}");

            Console.WriteLine(AddIfOdd(2, 4));
            Console.WriteLine(AddIfOdd(1, 4));
            Console.WriteLine(AddIfOdd(2, 1));

            const int i1 = 1;
            const int i2 = 4;
            int sum;

            if (TryAddIfOdd(i1, i2, out sum))
            {
                Console.WriteLine($"Sum equal to {sum}");
            }
            else
            {
                Console.WriteLine("Cannot count sum");
            }
        }

        static double FuncWithBigName(double x) {
            return x * x * x + 5 * x * x + 6;
        }

        // => FuncWithBigName(double x) =>  x * x * x + 5 * x * x + 6;

        static void Concat(string str1, string str2) => Console.WriteLine($"{str1}, {str2}");

        static void IncrementRef(ref int i) 
        {
            ++i;
            Console.WriteLine($"In Increment {i}");
        }

        static void Add(string str1, string str2)
        {
            str1 += str2;
            Console.WriteLine($"In Add {str1}");
        }

        static void AddRef( ref string str1, string str2)
        {
            str1 += str2;
            Console.WriteLine($"In AddRef {str1}");
        }

        static int AddIfOdd(int i1, int i2) 
        {
            return i1 % 2 == 0 && 2 % 2 == 0
                ? i1 + i2
                : 0;
        }

        // Patern try

        static bool TryAddIfOdd(int i1, int i2, out int sum)
        {
            if (i1 % 2 == 0 && 2 % 2 == 0)
            {
                sum = i1 + i2;
                return true;
            }
            sum = 0;
            return false;
        }
    }
}

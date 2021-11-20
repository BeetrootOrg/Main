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
    }
}

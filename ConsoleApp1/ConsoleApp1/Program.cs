namespace Console
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    class Program
    {
        static void Main()
        {
            double result = FuncWithABigName(5.5);
            System.Console.WriteLine($"{result}");
            ConCat("Hello", "Dima");
            int ai = 0;
            InrementReferenc(ref ai);
            Console.WriteLine($"In main {ai}");
            ai= 0;
            Inrement(ai);
            Console.WriteLine($"In main {ai}");

            string str = "Hello";
            Add(str, " dima");
            Console.WriteLine(str);
            AddRef(ref str, " dima");
            Console.WriteLine(str);
            Console.WriteLine(AddIfOdd(2, 4));
            Console.WriteLine(AddIfOdd(1, 4));
            Console.WriteLine(AddIfOdd(2, 5));
            int sum;
            const int i1 = 2;
            const int i2 = 4;
            if (TryAddIfOdd(i1,i2,out sum))
            {
                Console.WriteLine($"Sum equal to {sum}");
            }
            else
            {
                Console.WriteLine("Cannot count sum, becuse not odd");
            }
        }

        static double FuncWithABigName(double x)
        {
            return x * x * x + 5 * x * x + 6;
        }

        static void ConCat(string str1,string str2)
        {
            System.Console.WriteLine(str2+" , "+str1);
        }

        static void InrementReferenc(ref int i)
        {
            i++;
            System.Console.WriteLine($"Increment {i}");
        }

        static void Inrement(int i)
        {
            i++;
            System.Console.WriteLine($"Increment {i}");
        }

        static void Add(string str1,string str2)
        {
            str1 += str2;
            Console.WriteLine(str1);
        }

        static void AddRef(ref string str1, string str2)
        {
            str1 += str2;
            Console.WriteLine(str1);
        }

        static int AddIfOdd(int i1= 2, int i2 =2)
        {
            if (i1 % 2 == 0 && i2 % 2 == 0)
            {
                return i1 + i2;
            }
            return 0;
        }

        static bool TryAddIfOdd(int i1, int i2, out int Sum)
        {
            if (i1 % 2 == 0 && i2 % 2 == 0)
            {
                Sum = i1 + i2;
                return true;
            }
            Sum = 0;
            return false;
        }
    }
}
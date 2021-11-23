using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Max(-1, -2, -3, -4, -5, -6, -7, -2, -10));
            Console.WriteLine(Min(-1, -2, -3, -4, -5, -6, -7, -2, -10));
            Console.WriteLine(Max(-1, -2, -3));
            Console.WriteLine(Max(-1, -2, -3, -4));
            Console.WriteLine(Min(-1, -2, -3));
            Console.WriteLine(Min(-1, -2, -3, -4));
            Console.WriteLine(Repeat("Hello", 3));
        }
        static int Max(params int[] args )
        {
            int max = args[0];
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] > max)
                {
                    max = args[i];
                }
            }
            return max;
        }
        static int Max(int a, int b, int c)
        {
            int[] args = {a,b,c};
            int max = args[0];
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] > max)
                {
                    max = args[i];
                }
            }
            return max;
        }
        static int Max(int a,int b,int c, int d)
        {
            int[] args = { a, b, c, d };
            int max = args[0];
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] > max)
                {
                    max = args[i];
                }
            }
            return max;
        }
        static int Min(params int[] args)
        {
            int min = args[0];
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] < min)
                {
                    min = args[i];
                }
            }
            return min;
        }
        static int Min(int a, int b, int c)
        {
            int[] args = { a, b, c };
            int min = args[0];
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] < min)
                {
                    min = args[i];
                }
            }
            return min;
        }
        static int Min(int a, int b, int c, int d)
        {
            int[] args = { a, b, c, d };
            int min = args[0];
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] < min)
                {
                    min = args[i];
                }
            }
            return min;
        }
        static bool TrySumIfOdd(int a, int b, out int sum)
        {
            sum = a + b;
            return sum % 2 != 0;
        }
        static string Repeat(string x, int n)
        {
            string temp = string.Empty;
            for (int i = 0; i < n; i++)
            {
                temp += x;
            }
            return temp;
        }
    }
}
namespace ConsoleApp
{
    using System;
    class ConsoleApp
    {
        static int F(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n - M(F(n - 1));
            }
        }
        static int M(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else
            {
                return n - F(M(n - 1));
            }
        }
        static UInt64 Pow(UInt32 x, UInt32 y)
        {
            UInt64 result;

            if(y == 0)
            {
                return 1;
            }
            if(x == 0)
            {
                if (y == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            result = x;
            for (int i = 1; i < y; i++)
            {
                result *= x;
            }
            return result;
        }
        static string RecursiveDataConsole(int n)
        {
            if (n == 1)
            {
                return "1 ";
            }
            else
            {
                return (RecursiveDataConsole(n - 1) + n).ToString() + " ";
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/homework/05-debug \r\n");

            Console.WriteLine("1. F(n), M(n):");
            for (int n = 0; n < 10; n++)
            {
                Console.Write("F({0}) = {1}; ", n, F(n));
                Console.Write("M({0}) = {1}\r\n", n, M(n));
            }

            Console.WriteLine("\r\n2. Pow(X, Y):");
            for (UInt32 x = 0; x < 5; x++)
            {
                for (UInt32 y = 0; y < 7; y++)
                {
                    Console.Write("{0}^{1} = {2}; ", x, y, Pow(x, y));
                }
                Console.Write("\r\n");
            }

            Console.WriteLine("\r\n3. RecursiveDataConsole(10):");
            Console.WriteLine(RecursiveDataConsole(10));

            Console.Write("\r\n");
        }
    }
}

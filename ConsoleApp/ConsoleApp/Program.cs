using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            //F and M methods
            Console.WriteLine("F and M methods");
            Console.WriteLine(F(5));
            Console.WriteLine(M(4));
            //Pow method
            Console.WriteLine("Pow method");
            Console.WriteLine(Pow(2, 3));

            //AllNumbers method
            Console.WriteLine("AllNumbers method");
            AllNumbers(5);
        }

        //F and M methods
        static int F(int n)
        {
            if (n == 0) return 1;
            return n - M(F(n - 1));
        }
        static int M(int n)
        {
            if (n == 0) return 0;
            return n - F(M(n - 1));
        }

        //Pow method
        static int Pow(int x, int y)
        {
            if (y == 0) return 1;
            return x > 0 ? x * Pow(x, y - 1) : -x * Pow(x, y - 1);
        }

        //AllNumbers method
        static void AllNumbers(int n)
        {
            if (n > 1) AllNumbers(n - 1);
            if (n > 0)
            {
                Console.WriteLine(n);
            }
            else
            {
                Console.WriteLine("The number is less than 0");
            }
        }
    }
}
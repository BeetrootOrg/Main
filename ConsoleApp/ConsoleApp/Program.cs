using System;

namespace ConsoleApp
{
    class Program
    {
        const int maxInt= 2147483647;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the nubmers: ");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());
            int d = Convert.ToInt32(Console.ReadLine());
            int e = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nMax({a}, {b})= {Maxi(a, b)}");
            Console.WriteLine($"\nMax({a}, {b}, {c})= {Maxi(a, b, c)}");
            Console.WriteLine($"\nMax({a}, {b}, {c}, {d})= {Maxi(a, b, c, d)}");
            Console.WriteLine($"\nMax({a}, {b}, {c}, {d}, {e})= {Maxi(a, b, c, d, e)}");
            
            Console.WriteLine($"\nMin({a}, {b})= {Mini(a, b)}");
            Console.WriteLine($"\nMin({a}, {b}, {c})= {Mini(a, b, c)}");
            Console.WriteLine($"\nMin({a}, {b}, {c}, {d})= {Mini(a, b, c, d)}");
            Console.WriteLine($"\nMin({a}, {b}, {c}, {d}, {e})= {Mini(a, b, c, d, e)}");

            Console.WriteLine("Enter x and y: ");
            int x= Convert.ToInt32(Console.ReadLine());
            int y= Convert.ToInt32(Console.ReadLine());
            int db = 0;
            if (TryMulIfDividedByThree(x, y, out db))
            {
                Console.WriteLine($"One of the numbers is divisible by 3!\nMultiplication of these numbers is {db}");
            }
            else
            {
                Console.WriteLine($"No one of the numbers is divisible by 3!");
            }

            Console.WriteLine("Enter the line and the number n: ");
            string line=Console.ReadLine();
            int n=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Repeat({line}, {n})= {Repeat(line, n)}");
        }
        static int Maxi(int a, int b, int c = 0, int d = 0, int e = 0)
        {
            if (a > b) { b = a; }
            if (c > b) { b = c; }
            if (d > b) { b = d; }
            if (e > b) { b = e; }
            return b;
        }
        static int Mini(int a, int b, int c = maxInt, int d = maxInt, int e = maxInt)
        {
            if (a < b) { b = a; }
            if (c < b) { b = c; }
            if (d < b) { b = d; }
            if (e < b) { b = e; }
            return b;
        }

        static bool TryMulIfDividedByThree(int a, int b, out int d)
        {
            d = 0;
            if (a % 3 == 0 || b % 3 == 0) { d = a * b; return true; }
            return false;
        }

        static string Repeat(string str,int n)
        {
            string result = null;
            for (int i = 0; i < n; i++)
            {
                result += str;
            }
            return result;
        }
    }
}

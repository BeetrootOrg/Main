
using System;

namespace Nomework_05
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Write n:");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"F({n}) = {F(n)}");
            Console.WriteLine($"M({n}) = {M(n)}");


            Console.WriteLine("Write INTEGER X^Y:");
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{x}^{y} = {Pow(x, y)}");

            Console.WriteLine("Write N-series:");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Series(n));

        }

        static int F(int n)
        {
            if (n >= 0)
            {
                n -= M(F(n - 1));
            }
            return n;
        }

        static int M(int n)
        {
            if (n > 0)
            {
                n -= F(M(n - 1));
            }
            return n;
        }

        static int Pow(int x, int y)
        {
            if (y > 1)
            {
                x *= Pow(x, y - 1);
            }
            else if (y == 0)
            {
                x = 1;
            }
            return x;
        }

        static string Series(int n)
        {

            if (n > 0)
            {
                return Series(n - 1) + n + " ";
            }
            else
            {
                return null;
            }
        }
    }

}

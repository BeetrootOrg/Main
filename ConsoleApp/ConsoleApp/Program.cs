using System;

namespace Aaaa
{
    public class Program
    {
        static void Main/*text block*/()
        {
            Console.WriteLine("Counting F(n) and M(n):");

            Console.WriteLine("Write n:");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"F({n}) = {F(n)}");
            Console.WriteLine($"M({n}) = {M(n)}\n");

            Console.WriteLine("Counting x^y:");
            Console.WriteLine("Write x:");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write y:");

            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{x}^{y} = {Pow(x, y)}\n");

            Console.WriteLine("Writing numbers from 1 to n:");
            Console.WriteLine("Write n:");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Your row of numbers: \n{Series(n)}\n");
            Console.WriteLine("         Push any button to exit the programm\n");

        }
        static int F(int n)
        {
            if (n >= 0)
            {
                n = n -M(F(n-1));
            }
            return n;
        }
        static int M(int n)
        {
            if (n > 0)
            {
                n = n -F(M(n-1));
            }
            return n;
        }
        static int Pow(int x, int y)
        {
            if (y > 1)
            {
                x = x * Pow(x, y - 1);
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
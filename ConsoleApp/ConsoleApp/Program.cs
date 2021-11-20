using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int f0 = 0;
            int f1 = 1;
            int f = 0;
            for (int i = 2; i <= n; i++)
            { 
                f = f0 + f1;
                f0 = f1;
                f1 = f;

            }
            Console.WriteLine($"F({n}) = {f} ");
        }
    }
}

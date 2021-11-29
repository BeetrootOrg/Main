

namespace ConsoleApp
{
    using System;
    public class Program
    {
        static void Main()
        {
            Console.WriteLine(Pow(2, 8));
            Print(3, 8);
        }
        public static int Pow(int x, int y)
        {
            if (y == 0 && x > 0) return 1;
            else if (y == 1) return x;
            else return x * Pow(x, y - 1);

        }

        public static void Print(int x, int y)
        {
            if (x <= y)
            {
                Console.WriteLine(x);
                Print(++x, y);
            }
        }
    }


}
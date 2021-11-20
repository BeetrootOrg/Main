using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            const int n = 6;

            var a = 0;
            var b = 1;

            var res = 0;

            if (n == 0)
            {
                res = 0;
            }
            else if (n == 1)
            {
                res = 1;
            }
            else
            {
                var incr = n;
                while (incr-- > 0)
                {
                    res = b;
                    b = a + b;
                    a = b - a;
                }
            }

            Console.WriteLine(res);
        }
    }
}
namespace ConsoleApp
{
    using System;
    class ConsoleApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n other/04-kata\r\n");

            int f1 = 0;
            int f2 = 1;
            int fCalc = 0;

            Console.WriteLine(" {0}", f1);
            Console.WriteLine(" {0}", f2);
            for (int i = 2; i < 20; i++)
            {
                fCalc = f1 + f2;
                f1 = f2;
                f2 = fCalc;
                Console.WriteLine(" {0}", fCalc);
            }

            Console.Write("\r\n");
        }
    }
}

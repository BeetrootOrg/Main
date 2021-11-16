namespace ConsoleApp
{
    using System;
    class ConsoleApp
    {
        static long SumCalculate(int x, int y)
        {
            long sum = 0;
            Console.Write("Sum=");
            if (x < y)
            {
                Console.Write("{0}", x);
                sum = x;
                do
                {

                    sum += ++x;
                    Console.Write("+{0}", x);
                } while (x != y);
            }
            else if (y < x)
            {
                Console.Write("{0}", y);
                sum = y;
                do
                {
                    sum += ++y;
                    Console.Write("+{0}", y);
                } while (x != y);
            }
            else
            {
                Console.Write("{0}", x);
                sum = x;
            }
            return sum;
        }
        static long ReadConsoleAndSumCalculate()
        {
            int ConsoleA = 0;
            int ConsoleB = 0;
            long Sum = 0;

            Console.Write("\r\nEnter a: ");
            string ConsoleStringA = Console.ReadLine();
            try
            {
                ConsoleA = Convert.ToInt32(ConsoleStringA);
            }
            catch
            {
                Console.Write("Error!\r\n");
                return 0;
            }
            Console.Write("Enter b: ");
            string ConsoleStringB = Console.ReadLine();
            try
            {
                ConsoleB = Convert.ToInt32(ConsoleStringB);
            }
            catch
            {
                Console.Write("Error!\r\n");
                return 0;
            }
            Sum = SumCalculate(ConsoleA, ConsoleB);
            return Sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n 03-homework-operations\r\n");

            Console.WriteLine("={0}", SumCalculate(10, 12));
            Console.WriteLine("={0}", SumCalculate(5, 2));

            Console.WriteLine("={0}", ReadConsoleAndSumCalculate());

            Console.Write("\r\n");
        }
    }
}
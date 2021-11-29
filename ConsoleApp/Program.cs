namespace ConsoleApp
{
    using System;
    class ConsoleApp
    {
        static void ShowValue(int value)
        {
            Console.Write("+" + (value < 0 ? "(" + value + ")" : value));
        }
        static long SumCalculate(int x, int y)
        {
            long sum = 0;
            Console.Write("Sum = ");
            if (x < y)
            {
                Console.Write("{0}", x);
                sum = x;
                do
                {
                    sum += ++x;
                    ShowValue(x);
                } while (x != y);
            }
            else if (y < x)
            {
                Console.Write("{0}", y);
                sum = y;
                do
                {
                    sum += ++y;
                    ShowValue(y);
                } while (x != y);
            }
            else
            {
                Console.Write("{0}", x);
                sum = x;
            }
            return sum;
        }
        static int ReadConsoleValue(string str)
        {
            string? consoleString = null;
            bool success = false;
            int value = 0;

            while (!success)
            {
                Console.Write("Enter " + str + ": ");
                consoleString = Console.ReadLine();
                success = int.TryParse(consoleString, out value);
                if (!success)
                {
                    Console.Write("Error!\r\n");
                }
            }
            return value;
        }
        static long ReadConsoleAndSumCalculate()
        {
            int consoleA = 0;
            int consoleB = 0;

            consoleA = ReadConsoleValue("a");
            consoleB = ReadConsoleValue("b");

            return SumCalculate(consoleA, consoleB);
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

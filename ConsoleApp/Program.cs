namespace ConsoleApp
{
    using System;
    class ConsoleApp
    {
        static int F(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n - M(F(n - 1));
            }
        }
        static int M(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else
            {
                return n - F(M(n - 1));
            }
        }
        static UInt64 Pow(UInt32 x, UInt32 y)
        {
            UInt64 result;

            if(y == 0)
            {
                return 1;
            }
            if(x == 0)
            {
                if (y == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            result = x;
            for (int i = 1; i < y; i++)
            {
                result *= x;
            }
            return result;
        }
        static string RecursiveDataConsole(int n)
        {
            if (n == 1)
            {
                return "1 ";
            }
            else
            {
                return (RecursiveDataConsole(n - 1) + n).ToString() + " ";
            }
        }
        static long Fact(int n)
        {
            if(n == 0)
            {
                return 1;
            }
            return n * Fact(n - 1);
        }

        static void printArray(int[]arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.Write("\r\n");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/classroom/06-arrays \r\n");

            // int fact_int = 5;
            // Console.WriteLine("Factorial ({0}) = {1}", fact_int, Fact(fact_int));


            int[] array = { 1, 2, 3, 4, 5 };
            printArray(array);
            array[1] = 5;
            printArray(array);

            Console.Write("\r\n");
        }
    }
}

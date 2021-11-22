namespace ConsoleApp
{
    using System;
    class ConsoleApp
    {
        static int GetMax(int a, int b, int c)
        {
            return Math.Max(Math.Max(a, b), c);
        }
        static int GetMin(int a, int b, int c)
        {
            return Math.Min(Math.Min(a, b), c);
        }
        static bool TrySumifOdd(int a, int b, out int result)
        {
            result = a + b;
            if ((result & 1) == 1)
            {                
                return true;
            }
            else
            {
                return false;
            }
        }
        static void ShowSum(bool executResult, int sum)
        {
            if(executResult == true)
            {
                Console.WriteLine("{0} // Sum is Odd", sum);
            }
            else
            {
                Console.WriteLine("{0} // Sum is Even", sum);
            }
        }
        static string Repeat(string str, int repeatTimes)
        {
            if (repeatTimes-- > 0)
            {
                return str + Repeat(str, repeatTimes);
            }
            else
            {
                return null;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/homework/04-methods \r\n"); 
            
            Console.WriteLine("Get Max/Min:");
            int a = -5;
            int b = 3;
            int c = 15;
            Console.WriteLine("Enter numbers: {0} {1} {2}", a, b, c);
            Console.WriteLine("Max {0}", GetMax(a, b, c));
            Console.WriteLine("Min {0}\r\n", GetMin(a, b, c));


            Console.WriteLine("Calculate Sum:");
            int d = -5;
            int e = 4;
            int oddResult;
            Console.Write("{0} + {1} = ", d, e);
            ShowSum(TrySumifOdd(d, e, out oddResult), oddResult);

            Console.Write("\r\n");
            string _str = "str ";
            int repeatTimes = 3;
            Console.WriteLine("Repeat \"{0}\" {1} times:", _str, repeatTimes);
            Console.Write("{0}", Repeat(_str, repeatTimes));

            Console.Write("\r\n");
        }
    }
}

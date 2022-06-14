namespace ConsoleApp
{
    using System;
    class ConsoleApp
    {
        static int GetMax(int a, int b)
        {
            return Math.Max(a, b);
        }
        static int GetMax(int a, int b, int c)
        {
            return Math.Max(Math.Max(a, b), c);
        }
        static int GetMax(int a, int b, int c, int d)
        {
            return Math.Max(Math.Max(a, b), Math.Max(c, d));
        }
        static int GetMax(int a, int b, int c, int d, int e)
        {
            return Math.Max(Math.Max(Math.Max(a, b), Math.Max(c, d)), e);
        }
        static int GetMin(int a, int b)
        {
            return Math.Min(a, b);
        }
        static int GetMin(int a, int b, int c)
        {
            return Math.Min(Math.Min(a, b), c);
        }
        static int GetMin(int a, int b, int c, int d)
        {
            return Math.Min(Math.Min(a, b), Math.Min(c, d));
        }
        static int GetMin(int a, int b, int c, int d, int e)
        {
            return Math.Min(Math.Min(Math.Min(a, b), Math.Min(c, d)), e);
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
            int c = 54;
            int d = 75;
            int e = 21;
            Console.WriteLine("Enter numbers: {0} {1}", a, b);
            Console.WriteLine("Max {0}", GetMax(a, b));
            Console.WriteLine("Min {0}\r\n", GetMin(a, b));
            Console.WriteLine("Enter numbers: {0} {1} {2}", a, b, c);
            Console.WriteLine("Max {0}", GetMax(a, b, c));
            Console.WriteLine("Min {0}\r\n", GetMin(a, b, c));
            Console.WriteLine("Enter numbers: {0} {1} {2} {3}", a, b, c, d);
            Console.WriteLine("Max {0}", GetMax(a, b, c, d));
            Console.WriteLine("Min {0}\r\n", GetMin(a, b, c, d));
            Console.WriteLine("Enter numbers: {0} {1} {2} {3} {4}", a, b, c, d, e);
            Console.WriteLine("Max {0}", GetMax(a, b, c, d, e));
            Console.WriteLine("Min {0}\r\n", GetMin(a, b, c, d, e));


            Console.WriteLine("Calculate Sum:");
            int f = -5;
            int g = 4;
            int oddResult;
            Console.Write("{0} + {1} = ", f, g);
            ShowSum(TrySumifOdd(f, g, out oddResult), oddResult);

            Console.Write("\r\n");
            string _str = "str ";
            int repeatTimes = 3;
            Console.WriteLine("Repeat \"{0}\" {1} times:", _str, repeatTimes);
            Console.Write("{0}", Repeat(_str, repeatTimes));

            Console.Write("\r\n");
        }
    }
}

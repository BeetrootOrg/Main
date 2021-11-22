
using System;

namespace MyApp
{
    public class Program
    {
        static void Main() 
        {
            int x = 0;
            Console.WriteLine(RoundNumber(x));
        }
        public static double RoundNumber(double x)
        {
           
            return ((x / 5) +1) * 5 + ((x % 5) > 0 ? 5 : 0);
        }
    }
}
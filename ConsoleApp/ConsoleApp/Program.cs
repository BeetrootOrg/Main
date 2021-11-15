using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            double x = Convert.ToDouble(Console.ReadLine());
            // x^3+2*x^2+5*x+6
            //Console.WriteLine(x * x * x + 2 * x * x + 5 * x + 6);
            Console.WriteLine(Math.Pow(x, 2) + 2 * Math.Pow(x, 2) + 5 * x + 6);

            int incr = 5;
            int res1 = ++incr;//incr=6 res1=6
            int res2 = incr++;//res2=6 incr=7

            //bool logic
            bool bool1 = true;
            var bool2 = false;
            Console.WriteLine($"And: {bool1 && bool2}");
            Console.WriteLine($"Or: {bool1 || bool2}");
            Console.WriteLine($"Equal: {bool1 == bool2}");
            Console.WriteLine($"Not Equal: {bool1 != bool2}");
            Console.WriteLine($"Xor: {bool1 ^ bool2}");

            //math equality & comparison
            int first = 1;
            int second = 2;
            Console.WriteLine($"{first} > {second}: {first > second}");
            Console.WriteLine($"{first} <= {second}: {first <= second}");
            Console.WriteLine($"{first} == {second}: {first == second}");
            Console.WriteLine($"{first} != {second}: {first != second}");

            //int bool logic
            int coolVar1 = 3; //in bin = 1010
            int coolVar2 = 10;//in bin = 0011
                              //and    = 0010 -> 2
                              //or     = 1011 -> 11
            Console.WriteLine(coolVar1 & coolVar2);
            Console.WriteLine(coolVar1 | coolVar2);

        }
    }
}

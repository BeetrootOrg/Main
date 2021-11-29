using System;

namespace  ConsoleApp
{
    class Program
    {
        static void Main()
        {
            (int, string) tuple1 = (42,"string");
            
            Console.WriteLine(tuple1);

            tuple1.Item1 = 1;
            tuple1.Item2 = "str";
            
            (int number, string str) tuple2 = (42,"string");
            tuple2.number = 5;
            tuple2.str = "str3";
            Console.WriteLine(tuple2);

            //var (a, b) = tuple; Same as belo
            (int a, string b) = tuple1;

            Console.WriteLine(a);
            Console.WriteLine(b);

            tuple2 = tuple1;

        }

        
    }
}
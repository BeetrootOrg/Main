using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the str: ");
            string str = Convert.ToString(Console.ReadLine());
            if (str == "Ivan" || str == "ivan")
            {
                Console.WriteLine($"Hello, Ivan");
            }
            else
            {
                Console.WriteLine($"Hello, {str}");
            }

            int c = 10;
            int d;
            if (c ==10)
            {
                d = 20;
            }
            else
            {
                d = 0;
            }
            //ternar variant
            d = c == 10 ? 10 : 0;  

            Console.WriteLine("Enter the a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = 0;
            switch (a%2)
            {
                case 0:
                    b = a * 2;
                    break;
                case 1:
                    b = a * 3;
                    break;
                case 2:
                    b = a * 4;
                    break;
                case 3:
                    b = a * 5;
                    break;
                default:
                    b = 0;
                    break;
            }
            Console.WriteLine($"b = {b}");

            //ternar variant
            int e = a switch
            {
                0 => a * 2,
                1 => a * 3,
                2 => a * 4,
                3 => a * 5,
                _ => 0,
            };

            Console.WriteLine($"e = {e}");

        }
    }
}

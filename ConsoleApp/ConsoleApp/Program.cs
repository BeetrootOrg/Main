using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the str: ");
            string? str = Console.ReadLine();
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

            for (int i = 0; i <= 20; ++i)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine(i);
                }
            }
            //OR
            for (int i = 1; i <= 20; i+=2)
            {
                Console.WriteLine(i);
            }
            //OR
            for (int i = 0; i <= 10; ++i)
            {
                Console.WriteLine(i * 2 + 1);
            }
            bool success;
            int number;
            do
            {
                Console.WriteLine("Enter the NUMBER, pleeeeeeese");
                string strNumber = Console.ReadLine();
                success = int.TryParse(strNumber, out number);
                Console.WriteLine(success ? $"It is number- {number}" : $"It is not number! ");
            }
            while (!success);
        }
    }
}

using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Create a program that will start with declaration of two constants (X and Y) and will count the sum of all numbers between these constants. 
            If they are equal then sum should be one of them

            Example:
            X=10
            Y=12
            Sum=10+11+12=33
            */
            try
            {
                Console.WriteLine("Enter the x: ");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the y: ");
                int y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"X= {x}\nY= {y}");
                int sum = 0;
                if (x > y) { int temp = y; y = x; x = temp; }
                if (x == y) { Console.WriteLine($"Sum= {x}"); }
                else
                {
                    Console.Write($"Sum = ");
                    for (int i = x; i <= y; i++)
                    {
                        sum += i;
                        if (i == y) { Console.Write($"{i} = {sum} "); break; }
                        Console.Write($"{i} + ");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Invalid input! ");
            }
        }
    }
}

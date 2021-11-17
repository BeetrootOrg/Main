using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            /*1. написати код, що буде виводити у консоль число з протилежним знаком, наприклад для 5 результат будет -5, для -1 результат буде 1
              2. написати код, що буде виводити у консоль число зі знаком мінус, наприклад для 5 результат будет -5, для -1 результат буде -1
              3. написати код, що буде виводити у консоль чи є число квадратом якогось цілого числа, наприклад 25 -> true (5^2), 24 -> false,
                 9 -> true (3^2), 1 -> true (1^2), 0 -> true (0^2), -1 -> false
            */
            //1
            Console.WriteLine("Enter the x:");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(-x);
            //2
            Console.WriteLine(-Math.Abs(x));
            //3
            Console.WriteLine(Math.Sqrt(x) * Math.Sqrt(x) == x) ;

        }
    }
}

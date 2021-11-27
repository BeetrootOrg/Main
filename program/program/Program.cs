using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            bool sucsessX;
            bool sucsessY;
            string strNumX;
            string strNumY;
            int sum = 0;
            int X;
            int Y;



            do
            {
                Console.Write("Write X: ");
                strNumX = Console.ReadLine();
                sucsessX = int.TryParse(strNumX, out int parsX);
                Console.WriteLine(sucsessX ? $"It is number {parsX}" : "It is not number");
            } while (!sucsessX);

            do
            {
                Console.Write("Write Y: ");
                strNumY = Console.ReadLine();
                sucsessY = int.TryParse(strNumY, out int parsY);
                Console.WriteLine(sucsessY ? $"It is number {parsY}" : "It is not number");

            } while (!sucsessY);

            X = Convert.ToInt32(strNumX);
            Y = Convert.ToInt32(strNumY);            
            if (X == Y) ;

            if (X==Y)
            {
                for ( ; X <= Y; X++)
                {
                    //Console.WriteLine(sum += X);
                    sum += X;
                }
            }
            else
            {
                //Console.WriteLine($"Answer {sum = X}");
                sum = X;
            }

            Console.WriteLine($"Answer = {sum}");
        }
    }
}
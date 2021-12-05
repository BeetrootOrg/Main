namespace ConsoleApp
{

    class Program
    {
        static void Main()
        {
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            int s=0;

            if (x > y) (y, x) = (x, y);
            for (int i = x; i <= y; i++)
            {
                s += i;
            }
            Console.WriteLine(s);
          }

    }
}
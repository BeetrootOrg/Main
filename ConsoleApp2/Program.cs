namespace ConsoleApp2
{

    class Program
    {
        static void Main()
        {
            //Console.WriteLine(Max(3, 5));
            Console.WriteLine(Min(3, 5));
            Console.WriteLine(Min(3, 2));
            Console.WriteLine(Min(3, 7, 5));
            Console.WriteLine(Min(3, 7, 12, 5));
            Console.WriteLine(Min(3, 7, 12, 5, -1));
            Console.WriteLine(Max(4, 6));
            Console.WriteLine(Max(3, 7, 5));
            Console.WriteLine(Max(3, 7, 12, 5));
            Console.WriteLine(Max(3, 7, 12, 5, -1));
            Console.WriteLine(TryProdIfDivisibleBy3Present(5, 7));
            Console.WriteLine(TryProdIfDivisibleBy3Present(3, 7));
            Console.WriteLine(Repeat("Dima~", 7));
        }
        static double Min(double x1, double x2, double x3= Double.PositiveInfinity, double x4 = Double.PositiveInfinity, double x5 = Double.PositiveInfinity)
        {
            return Math.Min(Math.Min(Math.Min(Math.Min(x1, x2),x3),x4),x5);
        }
        static double Max(double x1, double x2, double x3 = Double.NegativeInfinity, double x4 = Double.NegativeInfinity, double x5 = Double.NegativeInfinity)
        {
            return Math.Max(Math.Max(Math.Max(Math.Max(x1, x2), x3), x4), x5);
        }
 
        static object TryProdIfDivisibleBy3Present(int x, int y)

        {
            if (!Convert.ToBoolean((x % 3) * (y % 3)))
            {
                return x*y;
            }
            return false;
        }
       
        static string Repeat(string s, int n)
        {
            string ss = "";
            for (int i = n; i >= 1; --i)
            {
                ss += s;
            }
            return ss;
        }
    }
}
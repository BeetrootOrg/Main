namespace ConsoleApp2
{

    class Program
    {
        static void Main()
        {
            Console.WriteLine(Max(3, 5));
            Console.WriteLine(Min(3, 5));
            Console.WriteLine(TrySumIfOdd(4, 4, out bool y));
            Console.WriteLine(TrySumIfOdd(4, 5, out bool z));
            Console.WriteLine(Max(3, 7, 5));
            Console.WriteLine(Max(3, 7, 12, 5));
            Console.WriteLine(Repeat("Dima~", 7));
        }
        static double Max(double x, double y)
        {
            return Math.Max(x, y);
        }
        static double Min(double x, double y)
        {
            return Math.Min(x, y);
        }
        static bool TrySumIfOdd(int x, int y, out bool isodd)
        {
            return isodd = Convert.ToBoolean((x + y) % 2);
        }
        static double Max(double x, double y, double z)
        {
            return Math.Max(Math.Max(x, y), z);
        }
        static double Max(double x, double y, double z, double q)
        {
            return Math.Max(Math.Max(Math.Max(x, y), z), q);
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

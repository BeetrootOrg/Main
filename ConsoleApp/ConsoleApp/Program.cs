namespace ConsoleApp
{
    class Program
    {
        static int F(int n) => n == 0 ? 1 : n - M(F(n - 1));
        static int M(int n) => n == 0 ? 0 : n - F(M(n - 1));

        static int Pow(int x, int y) => y == 1 ? x : x * Pow(x, y - 1);

        static void ShowAllUntil(int n)
        {
            if (n > 1) ShowAllUntil(n - 1);
            System.Console.WriteLine(n);
        }

        static void Main()
        {
            System.Console.WriteLine(Pow(3, 2));
            ShowAllUntil(3);
        }
    }
}
namespace Homework5
{
    class Homework5
    {
        static int getFValue(int n)
        {
            return n == 0 ? 1 : n - getMValue(getFValue(n - 1));
        }

        static int getMValue(int n)
        {
            return n == 0 ? 0 : n - getFValue(getMValue(n - 1));
        }
        
        static int Pow(int x, int y)
        {
            return y != 1 ? x * Pow(x, y - 1) : x;
        }

        static string NthNumber(int n, int start = 1)
        {
            // return n != 1 ? $"{n}\n" + NthNumber(n - 1) : "" + n; but this is the opposite (N...1)

            if (n < 2)
            {
                return $"{start}";
            }
            else
            {
                --n;
                Console.WriteLine(start);
                return NthNumber(n, start + 1);
            }
        }

        public static void Main()
        {
            Console.WriteLine(getFValue(1));
            Console.WriteLine(getMValue(1));
            Console.WriteLine(Pow(3, 3));
            Console.WriteLine(NthNumber(6));
        }
    }
}

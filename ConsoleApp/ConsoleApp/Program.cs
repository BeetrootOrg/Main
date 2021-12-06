using System.Linq;

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

        static bool Compare(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    return false;
                }
            }

            return true;
        }

        static void Analyze(string str, out int digits)
        {
            digits = 0;

            foreach (var symbol in str)
            {
                if (char.IsDigit(symbol))
                {
                    ++digits;
                }
            }
        }

        static string Sort(string str)
        {
            string lower = str.ToLower();
            char[] charArray = new char[str.Length];

            // 1. copy lower to charArray
            for (int i = 0; i < lower.Length; i++)
            {
                charArray[i] = lower[i];
            }

            // ToDo: 2. sort char array

            // 3. return result
            return new string(charArray);
        }

        static char[] Duplicate(string str)
        {
            string lower = str.ToLower();

            int lastIndex = 0;
            char[] duplicates = new char[lower.Length];

            for (int i = 0; i < lower.Length; i++)
            {
                var symbol = lower[i];
                if (lower[(i + 1)..].Contains(symbol))
                {
                    var existsInDuplicates = false;
                    for (int j = 0; j < lastIndex; j++)
                    {
                        if (duplicates[j] == symbol)
                        {
                            existsInDuplicates = true;
                            break;
                        }
                    }

                    if (!existsInDuplicates)
                    {
                        duplicates[lastIndex++] = symbol;
                    }
                }
            }

            return duplicates;
        }

        static void Main()
        {
            System.Console.WriteLine(Pow(3, 2));
            ShowAllUntil(3);
        }
    }
}
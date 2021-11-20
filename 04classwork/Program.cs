using System;

namespace Classwork4
{

    class Classwork4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test");

            int ai = 0;
            Increment(ai);
            //Console.WriteLine(ai);

            const int i = 2;
            const int j = 2;

            if (TryAddIfEven(i, j, out int sum))
            {
                Console.WriteLine($"The values are even - {sum}");
            } else
            {
                Console.WriteLine("The values are not even");
            }
        }

        static void Increment(int i)
        {
            ++i;
            Console.WriteLine(i);
        }

        static void IncrementRef(ref int i)
        {
            ++i;
            Console.WriteLine(i);
        }

        static bool TryAddIfEven(int i1, int i2, out int sum)
        {
            if (i1 % 2 == 0 && i2 % 2 == 0)
            {
                sum = i1 + i2;
                return true;
            }
            sum = 0;
            return false;
        }
    }
}

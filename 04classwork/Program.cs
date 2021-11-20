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
            Console.WriteLine(ai);
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
    }
}

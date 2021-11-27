using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var source = new[] { 1, 2, 3 };
            var destination = new int[source.Length];

            Copy(source, destination);

            Print(destination);
        }

        static void Copy(int[] source, int[] destination)
        {
            for (int i = 0; i < source.Length; i++)
            {
                destination[i] = source[i];
            }
        }

        static void Print(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
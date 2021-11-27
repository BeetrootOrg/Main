using System;
namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            int[] original = { 1, 2, 3, 4, 5, 6 };
            foreach (var item in CopyArr(original))
            {
                Console.WriteLine(item);
            }
        }
        static int[] CopyArr(int[] original)
        {
            int[] copy = new int[original.Length];
            Array.Copy(original, copy, original.Length);
            return copy;
        }
    }
}
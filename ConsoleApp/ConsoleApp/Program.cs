using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            char[] arr = new[] { (char)65, 'A', (char)0x41, '\u0041' }; // the same symbol 'A'

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
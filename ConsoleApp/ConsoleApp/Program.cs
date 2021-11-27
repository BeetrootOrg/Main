using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            char[] arr = new[] { (char)65, 'A', (char)0x41, '\u0041', 'a', '9', '\u1234' }; // first four -> the same symbol 'A'

            foreach (var item in arr)
            {
                Console.WriteLine($"Symbol: {item}");
                Console.WriteLine($"Is Lower: {char.IsLower(item)}"); // false
                Console.WriteLine($"Is Upper: {char.IsUpper(item)}"); // true
                Console.WriteLine($"Is Number: {char.IsNumber(item)}"); // false
                Console.WriteLine($"Is Ascii: {char.IsAscii(item)}"); // true
                Console.WriteLine($"Is Letter: {char.IsLetter(item)}"); // true
            }
        }
    }
}
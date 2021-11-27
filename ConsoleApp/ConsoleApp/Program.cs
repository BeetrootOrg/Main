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
                Console.WriteLine($"Is Lower: {char.IsLower(item)}");
                Console.WriteLine($"Is Upper: {char.IsUpper(item)}");
                Console.WriteLine($"Is Number: {char.IsNumber(item)}");
                Console.WriteLine($"Is Ascii: {char.IsAscii(item)}");
                Console.WriteLine($"Is Letter: {char.IsLetter(item)}");
                Console.WriteLine($"Is Letter: {char.IsControl(item)}");

                Console.WriteLine($"To Lower: {char.ToLower(item)}");
                Console.WriteLine($"To Upper: {char.ToUpper(item)}");
            }

            char result;

            Console.WriteLine($"TryParse 'b': {char.TryParse("b", out result)}. Result: {result}");
            Console.WriteLine($"TryParse 'bb': {char.TryParse("bb", out result)}. Result: {result}");
        }
    }
}
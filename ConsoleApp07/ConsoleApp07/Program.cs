using System;

namespace ConsoleApp07
{
    class Program
    {
        static void Main() 
        {
            char c = (char)65; // 'A'
            Console.WriteLine(c);
            char x = 'A';
            Console.WriteLine(x == c);
            char y = (char)0x41;

            char[] arr = new[] { (char)65, 'a', (char)0x41, '1' };

            foreach (var item in arr)
            {
                Console.WriteLine(item);
                Console.WriteLine($"Is lower:{char.IsLower(item)}");
                Console.WriteLine($"Is upper: {char.IsUpper(item)}");
                Console.WriteLine($"Is Number: {char.IsNumber(item)}");
                Console.WriteLine($"Is Ascii: {char.IsAscii(item)}");
                Console.WriteLine($"Is Letter: {char.IsLetter(item)}");
                Console.WriteLine($"Is Letter: {char.IsControl(item)}");

                Console.WriteLine($"To Lower: {char.ToLower(item)}");
                Console.WriteLine($"To Upper: {char.ToUpper(item)}");



            }
            char result;
            Console.WriteLine($"TryParse 'b': {char.TryParse("b", out result)}, Result: {result}");

            Console.WriteLine("STRINGS");


            string formatted = "Hello, {0}";
            Console.WriteLine(string.Format(formatted, "Evgeniy"));

            formatted = "{0} = {1}";
            Console.WriteLine(formatted, "3^2", 3 * 3);

            string str = "Thes is string"; // string with error
            var d = str[2];

            Console.WriteLine($"Error in symbil '{d}'");

            var substring = str[0..^5]; // cut the last 5 symbols
            Console.WriteLine($"Substring 0..^5: {substring}");


            string str1 = "Dima";
            string str2 = "dima";

            Console.WriteLine(str1 == str2);// false
            Console.WriteLine(str1.Equals(str2, StringComparison.OrdinalIgnoreCase)); // true

        }
    }
}

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

            Console.WriteLine("STRING\n");

            string formatted = "Hello, {0}";
            Console.WriteLine(string.Format(formatted, "Dima"));

            formatted = "{0} = {1}";
            Console.WriteLine(formatted, "3^2", 3 * 3);

            formatted = "{0} says: 'I am {0}'";
            Console.WriteLine(formatted, "Dima");

            formatted = "Some stuff: {0}, {1}, {2}, {0}, {3}, {5}";
            Console.WriteLine(formatted, "Dima", 42, 'c', true, 0, -5);

            formatted = "{0}, {4}";
            Console.WriteLine(formatted, "Dima", null, null, null, -5);
            Console.WriteLine($"{42} is a number");

            string str = "Thes is string"; // string with error

            char c = str[2];
            Console.WriteLine($"Error in symbol '{c}'");

            string substring = str[0..^5];
            Console.WriteLine($"Substring 0..^5: {substring}");

            string[] arrayOfString = { "1", "42", "68" };
            int[] parsed = new int[arrayOfString.Length];
            for (int i = 0; i < arrayOfString.Length; i++)
            {
                parsed[i] = int.Parse(arrayOfString[i]);
            }

            string str1 = "Dima";
            string str2 = "dima";

            Console.WriteLine("String comparison");
            Console.WriteLine(str1 == str2); // false, by default Ordinal
            Console.WriteLine(str1.Equals(str2, StringComparison.OrdinalIgnoreCase)); // true
            Console.WriteLine("c".Equals("с", StringComparison.InvariantCulture)); // false
            Console.WriteLine("11.01".Equals("11,01", StringComparison.InvariantCulture)); // false

            str1 = "abc";
            str2 = "dce";

            // if result <0 then str1 < str2
            // if result ==0 then str1 == str2
            // if result >0 then str1 > str2
            Console.WriteLine(str1.CompareTo(str2)); // -1
        }
    }
}
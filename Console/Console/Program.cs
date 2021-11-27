using System;
using System.Globalization;

namespace Program
{

    class Program
    {
        static void Main()
        {
            char c = (char)0x41;
            char[] arr = new[] { (char)0x41, (char)65, 'A', '\u0041','a','9' , '\u5678'};
            foreach (char c2 in arr)
            {
                Console.WriteLine($"Symbol {c2}");
                Console.WriteLine($"Is lower { Char.IsLower(c2)}");
                Console.WriteLine($"Is upper {Char.IsUpper(c2)}");
                Console.WriteLine($"Is number { Char.IsNumber(c2)}");
                Console.WriteLine($"Is ASCII { Char.IsAscii(c2)}");
                Console.WriteLine($"Is Letter { Char.IsLetter(c2)}");
                Console.WriteLine($"ToLower  { Char.ToLower(c2)}");
                Console.WriteLine($"ToUpper  { Char.ToUpper(c2)}");
            }
            char res;
            Console.WriteLine($"Try parse {char.TryParse("b",out res)}");

            string formated = "Hello, {0}";
            Console.WriteLine(string.Format(formated, "Dima"));

            formated = "{0} = {1}";
            Console.WriteLine(formated, "x^2", 3 * 3);
            string str = "Thes is string";
            var s = str[2];

            Console.WriteLine(s);
            var substring = str[0..^5];
            Console.WriteLine(substring);

            string str1 = "Dima";
            string str2 = "dima";
            Console.WriteLine(str1.Equals(str2,StringComparison.InvariantCulture));
            Console.WriteLine(str1.Equals(str2, StringComparison.OrdinalIgnoreCase));

        }


  
    }
}
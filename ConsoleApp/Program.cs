using System;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {

            char[] arr = new[] { (char)65, 'A', (char)0x41, '\u0041','a', '9','\u1234' }; //same symbol A
            foreach (var item in arr)
            {
                Console.WriteLine(item);
                Console.WriteLine($"Char is lower: {Char.IsLower(item)}");//false
                Console.WriteLine($"Char is number: {Char.IsNumber(item)}"); //false
                Console.WriteLine($"Char is Letter: {Char.IsLetter(item)}"); //false
                Console.WriteLine($"Char is Ascii: {Char.IsAscii(item)}"); //false

                Console.WriteLine($"Char to lower: {Char.ToLower(item)}"); 
                Console.WriteLine($"Char to upper: {Char.ToUpper(item)}"); 
            }
            char result;
            Console.WriteLine($"try parse'b':{char.TryParse("b",out result)}.Result:{result}");
            Console.WriteLine($"try parse'bb':{char.TryParse("bb", out result)}.Result:{result}");

            Console.WriteLine("Strings");
            string formatted = "Hello,{0}";
            Console.WriteLine(string.Format(formatted,"Rus"));
            formatted = "{0}={1}";
            Console.WriteLine(formatted, "3^2", 3*3);
            formatted = "Some stuff: {0},{1},{2},{3},{5}";
            Console.WriteLine(formatted, "Rus",42,'c',true,0,-3);
            formatted = "{0},{4}";
            Console.WriteLine(formatted,1,2,3,4,5,6);

            string str = "thes is string";//string with error
            var c = str[2];
            Console.WriteLine($"Error in symbol: {c}");

            var substring = str[0..^5];
            Console.WriteLine($"Substring 0..^5: {substring}");

            string[] arrayOfString = { "1", "42", "35" };
            int[] parsed = new int[arrayOfString.Length];
            for (int i = 0; i < arrayOfString.Length; i++)  
            {
                parsed[i] = int.Parse(arrayOfString[i]);
            }
            string str1 = "Dima";
            string str2 = "dima";
            Console.WriteLine("String comparison");
            Console.WriteLine(str1==str2); //false
            Console.WriteLine(str1.Equals(str2,StringComparison.OrdinalIgnoreCase)); //true
            Console.WriteLine("c".Equals("с",StringComparison.InvariantCulture)); //false
            Console.WriteLine("12.1".Equals("12,1", StringComparison.InvariantCulture)); //false

            str1 = "1abd";
            str2 = "abd";
            //if result<0 then str1<str2;
            //if result==0 then str1==str2;
            //if result>0 then str1>str2;
            Console.WriteLine(str1.CompareTo(str2));

            int[] intArray = new int[50];
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = i;
            }
           
            Console.WriteLine(string.Join(", ",intArray));

            // 3. using StringBuilder
            StringBuilder sb = new StringBuilder();
            foreach (var item in intArray)
            {
                // 1. extra comma
                sb.Append(item).Append(", ");
            }

            Console.WriteLine(sb.ToString().Trim().TrimEnd(','));

        }
    }
}
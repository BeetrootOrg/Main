using System;
using System.Text;
namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            /*            char[] arr = new[] { (char)65, 'A', (char)0x41, '\u0041', 'a', '9' };

                        foreach (var x in arr)
                        {
                            Console.WriteLine($"Symbol {x}");
                            Console.WriteLine($"Is Lower: {char.IsLower(x)}"); //false
                            Console.WriteLine($"Is Upper: {char.IsUpper(x)}"); //true
                            Console.WriteLine($"Is Number: {char.IsNumber(x)}"); //false
                            Console.WriteLine($"Is Ascii: {char.IsAscii(x)}"); //true
                            Console.WriteLine($"Is Letter: {char.IsLetter(x)}"); //true

                            Console.WriteLine($"Is Letter: {char.ToLower(x)}"); //false
                            Console.WriteLine($"Is Letter: {char.ToUpper(x)}"); //true

                        }

                        char result;
                        Console.WriteLine($"TryParse 'b': {char.TryParse("b", out result)}. Result:{result}");
                        Console.WriteLine($"TryParse 'bb': {char.TryParse("bb", out result)}. Result:{result}");*/

            /*       string formatted = "Hello, {0}";
                   Console.WriteLine(string.Format(formatted, "Sasha"));
                   formatted = "{0} = {1}";
                   Console.WriteLine(formatted, "3^2", 3 * 3);
                   formatted = "{0} says: 'I am {0}'";
                   Console.WriteLine(formatted, "Sasha");

                   formatted = "Some stuff: {0} {1} {2} {3}";
                   Console.WriteLine(formatted, "Sasha", "likes", "to", "sleep");
                   formatted = "Some stuff: {0} {3}";
                   Console.WriteLine(formatted, "Sasha", "likes", "to", "sleep");


                   string str = "This is strimg";
                   char c = str[2];
                   Console.WriteLine($"Error in symbol '{c}'");

                   string substring = str[0..^5];
                   Console.WriteLine($"Substring 0..^5: {substring}");

                   string[] arrayOfString = { "1", "42", "68" };
                   int[] parsed = new int[arrayOfString.Length];
                   for (int i = 0; i < arrayOfString.Length; i++)
                   {
                       parsed[i] = int.Parse(arrayOfString[i]);
                   }*/

            string str1 = "abc";
            string str2 = "dce";
            /*            Console.WriteLine(str1 == str2); //false
                        Console.WriteLine(str1.Equals(str2, StringComparison.OrdinalIgnoreCase));
                        Console.WriteLine("c".Equals("с", StringComparison.InvariantCulture)); //false
                        Console.WriteLine("1.5".Equals("1,5", StringComparison.InvariantCulture)); //false


                        //if result < 0 then str1 < str2
                        //if result == 0 then str1 == str2
                        //if result > 0 then str1 > str2
                        Console.WriteLine(str1.CompareTo(str2));

                        str1 = "abc";
                        str2 = "ABC";

                        Console.WriteLine(str1.CompareTo(str2));*/

            str1 = "This is a string";
            Console.WriteLine($"Ends with: {str1.EndsWith("this is")}");
            Console.WriteLine($"Starts with: {str1.StartsWith("this is")}");
            Console.WriteLine($"Contains: {str1.Contains("is a")}");
            Console.WriteLine($"index of a: {str1.IndexOf('a')}");
            Console.WriteLine($"index of is: {str1.IndexOf("is")}");
            Console.WriteLine($"Last index of is: {str1.LastIndexOf("is")}");
            Console.WriteLine($"Last index of IS: {str1.LastIndexOf("IS")}");
            Console.WriteLine($"Last index of IS(ignore case): {str1.LastIndexOf("IS", StringComparison.OrdinalIgnoreCase)}");
            Console.WriteLine($"index of 'i' or 'h': {str1.IndexOfAny(new[] { 'i', 'h' })}");

            Console.WriteLine($"To Lower: {str1.ToLower()}");
            Console.WriteLine($"To Upper: {str1.ToUpper()}");

            int[] intArray = new int[50];
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = i;
            }

            //1. Join - the best way
            Console.WriteLine(String.Join(", ", intArray));
            //2. using string concatenation (the worst)
            string concatResult = string.Empty;
            foreach (var item in intArray)
            {
                //we create 50 new strings each assignment
                //extra comma in the end. to fix trim can be used
                concatResult += item + ", ";
            }
            Console.WriteLine(concatResult.Trim().TrimEnd(','));

            //3. using StringBuilder
            StringBuilder sb = new StringBuilder();
            foreach (var item in intArray)
            {
                //extra comma in the end. to fix trim can be used
                sb.Append(item).Append(", ");
            }

            Console.WriteLine(sb.ToString().Trim().TrimEnd(','));
        }



    }
}
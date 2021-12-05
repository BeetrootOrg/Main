namespace ConsoleApp
{
    using System;

    using System.Text;
    class Program
    {
        static void Main()
        {
            string s1 = "hello";
            string s2 = "hello";
            string s3 = "salut";
            string s4 = "~crisis2022";

            Console.WriteLine(Compare(s1, s2));
            Console.WriteLine(Compare(s2, s3));
            Console.WriteLine(Compare(s2, s3));

            Analyze(s4, out int c, out int d, out int s);
            Console.WriteLine("{0} characters {1} digits {2} special symbols", c, d, s);

            Console.WriteLine(Sort("The quick brown fox jumped over the lazy dog"));
            Console.WriteLine(Duplicate("The quick brown fox jumped over the lazy dog"));
        }
        public static bool Compare(string first, string second)
        {
            char[] str1 = first.ToCharArray();
            char[] str2 = second.ToCharArray();
            if (first.Length == second.Length)
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    if (str1[i] != str2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }

        }


        public static void Analyze(string str, out int alphabet, out int digits, out int special)
        {
            alphabet = 0;
            digits = 0;
            special = 0;
            char[] ca = str.ToCharArray();
            foreach (char c in ca)
            {
                if (Char.IsLetter(c))
                {
                    alphabet += 1;
                }
                else if (Char.IsDigit(c))
                {
                    digits += 1;
                }
                else if (Char.IsSymbol(c) || Char.IsPunctuation(c) || Char.IsWhiteSpace(c))
                {
                    special += 1;
                }
            }
        }


        public static string Sort(string str)
        {
            char[] array = str.ToLower().ToCharArray();
            char key;
            for (int i = 1; i < array.Length; i++)
            {
                key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(array);
            return sb.ToString();
        }

        public static string Duplicate(string str)
        {
            char[] array = str.ToLower().ToCharArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        sb.Append(array[i]);
                        break;
                    }
                }
            }

            //to remove dublicates of dublicates

            string strx = sb.ToString();
            var stringBuilder = new StringBuilder(strx);

            foreach (char c in strx)
            {
                stringBuilder.Replace(c.ToString(), string.Empty)
                             .Append(c.ToString());
            }
            return stringBuilder.ToString();
        }



    }
}
namespace Console
{
    using System;
    using System.Text;
    public class Program
    {
        static void Main()
        {
            string t1 = "Hello my darlings!";
            string t2 = "Hello my derlings!";
            int a;
            int b;
            int c;
            Console.WriteLine(Compare(t1,t2));
            Analyze(t1, out a, out b, out c);
            Console.WriteLine($"{t1}, alf {a}, num {b}, spec {c}");
            Console.WriteLine($"Origin{t2} sorted {Sort(t2)}");
            Console.WriteLine(Duplicate(t1));
        }

        //Compare that will return true if 2 strings are equal, otherwise false, but do not use build-in method
        public static bool Compare(string first, string second)
        {
            bool result = false;
            char[] str1 = first.ToCharArray();
            char[] str2 = second.ToCharArray();
            if(str1.Length != str2.Length)
            {
                return false;
            }
            else
            {
                for(int i = 0; i < str1.Length; i++)
                {
                    if(str1[i] != str2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        //Analyze that will return number of alphabetic chars in string, digits and another special characters
        public static void Analyze(string row, out int alphabet,out int digits, out int special)
        {
            alphabet = 0;
            digits = 0;
            special = 0;
            char[] vs = row.ToCharArray();
            foreach(char c in vs)
            {
                if (Char.IsLetter(c))
                {
                    alphabet += 1;
                }
                if (Char.IsDigit(c))
                {
                    digits += 1;
                }
                if (Char.IsSymbol(c) || Char.IsPunctuation(c) || Char.IsWhiteSpace(c))
                {
                    special += 1;
                }
            }
        }

        //Sort that will return string that contains all characters from input string sorted in alphabetical order(e.g. 'Hello' -> 'ehllo')
        public static string Sort(string str)
        {
            var tmp = str.ToLower();
            char[] vs = tmp.ToCharArray();
            InsertCharSort(ref vs);
            StringBuilder sb = new StringBuilder();
            sb.Append(vs);
            return sb.ToString();

        }

        //Duplicate that will return array of characters that are duplicated in input string (e.g. 'Hello and hi' -> ['h', 'l'])

        public static char[] Duplicate(string str)
        {
            char[] vs = str.ToCharArray();
            StringBuilder tmp = new StringBuilder();
            int x = 1;
            foreach (char c in vs)
            {
                for (int i = x; i < vs.Length; i++)
                {
                    if(c == vs[i]) { tmp.Append(c);break; }
                }
                x++;
            }
            return tmp.ToString().ToCharArray();
        
        }

        //-----------------------------------------------------------------------------------------------------
        //insertion sort
        public static void InsertCharSort(ref char[] array)
        {
            char key;
            for (int i = 1; i < array.Length; i++)
            {
                int j = i - 1;
                key = array[i];
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }

 


    }
}
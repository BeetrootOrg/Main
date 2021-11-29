namespace Console
{
    using System;
    public class Program
    {
        static void Main()
        {
            Console.WriteLine($"{Compare("aaa","aab")}");
            Console.WriteLine($"{Compare("aaa", "aaa")}");
            Console.WriteLine($"{Compare("aab", "aaa")}");
        }

        public static int Compare(string str1, string str2)
        {
            char[] chars1 = str1.ToCharArray();
            char[] chars2 = str2.ToCharArray();
            int cs1 = 0;
            int cs2 = 0;
            for(int i = 0; i < chars1.Length; i++)
            {
                cs1 += chars1[i];
            }
            for(int i = 0;i < chars2.Length; i++)
            {
                cs2 += chars2[i];
            }
            if(cs1 > cs2) return 1;
            else if(cs1 < cs2) return -1;
            else return 0;
        }
    }
}

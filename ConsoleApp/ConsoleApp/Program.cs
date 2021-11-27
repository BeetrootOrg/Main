using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] b = new int[9];

            Copy(ref a, b);

            foreach(var el in b)
            {
                Console.WriteLine(el);
            }   

        }
        public static void Copy(ref int[] Arr1,int[] Arr2)
        {
            for(int i = 0; i < Arr2.Length; i++)
            {
                Arr2[i] = Arr1[i];
            }
        }

    }
}

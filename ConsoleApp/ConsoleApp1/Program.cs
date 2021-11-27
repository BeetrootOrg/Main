namespace Console
{
    using System;
    public class Program
    {
        static void Main()
        {

        }

        public static void Copy(ref int[] toArr, int[] fromArr)
        {
            int[] resArr = new int[fromArr.Length];
            for (int i = 0; i < fromArr.Length; i++)
            {                
                resArr[i] = fromArr[i];
                toArr = resArr;
            }
        }
    }
}

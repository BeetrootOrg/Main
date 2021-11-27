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
            for(int i = 0; i < toArr.Length; i++)
            {
                int[] resArr = new int[fromArr.Length];
                resArr[i] = fromArr[i];
                toArr = resArr;
            }
        }
    }
}

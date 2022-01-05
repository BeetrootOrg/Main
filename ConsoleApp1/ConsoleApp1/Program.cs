namespace Homework
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;
    using System.Formats;
    using System.Text.RegularExpressions;

    public static class MyExtensions
    {
        public static bool IsWeekend(this DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday) return true;
            else return false;
        }

        public static bool IsIsWorkday(this DateTime date)
        {
            return !IsWeekend(date);
        }

        public static int[,] ChunkBy(this int[] array, int chunk)
        {
            int c = chunk;
            int count = array.Length / chunk;
            int[,] splited = new int[count,chunk];
            int cb = 0;
            int sb = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (cb < chunk)
                {
                    splited[sb,cb] = array[i];
                    cb++;
                }
                else if(cb >= chunk)
                {
                    sb++;
                    cb = 0;
                    splited[sb, cb] = array[i];
                    cb++;
                }
                if(i == array.Length - 1&&cb<chunk)
                {
                    for(;cb< chunk; cb++)
                    {
                        splited[sb, cb] = 0;
                    }
                }
            }
            return splited;
        }
    }

    public class Program
    {

        public static void Main()
        {
           
        }


  

    }
}
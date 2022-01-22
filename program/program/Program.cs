using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class DateTimeExtensions
    {
        public static bool IsWeekend(this DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsWorkday(this DateTime date) => !date.IsWorkday();

    }
    static class ChunkByCollection<T>
    {
        public static List<List<T>> ChunkBy(List<T> list, int size)
        {
            var newList = new List<List<T>>();
            for (int i = 0; i < list.Count; i += size)
            {
                newList.Add(list.GetRange(i, Math.Min(size, list.Count - i)));
            }

            return newList;
        }
    }

    class Program
    {
        
        static void Main()
        {

            var list = new List<int> { 1, 2, 3, 5, 6, 8, 9, 10, 11, 13 , 14};
            var chunks = ChunkByCollection<int>.ChunkBy(list, 3);
            foreach (var chunk in chunks)
            {
                Console.Write($"[");
                ShowAll<int>(chunk);
                Console.Write($"]");
            }
        }

        public static void ShowAll<T>(List<T> list)
        {

            foreach (T item in list)
            {
                Console.Write(item);
                Console.Write(" ");
            }

        }
    }

}


using System;
using System.Collections.Generic;
using System.Linq;

/* IsWeekend(date) extension to DateTime that will return true if date is weekday
IsWorkday(date) extension to DateTime that will return true if date is working day
ChunkBy(collection, size) extension to collection that will return a collection of collections with specified size. 
E.g. ChunkBy([1, 2, 3, 4, 5], 2) => [[1, 2], [3, 4], [5]]
*/

namespace ConsoleApp
{

    #region ChunkBy

    static class CollectionExtention<T>
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
    #endregion

    #region DateTime Extension
    static class DateTimeExtensions
    {
        public static bool IsWorkday(this DateTime dateTime) =>
            (dateTime.DayOfWeek != DayOfWeek.Sunday && dateTime.DayOfWeek != DayOfWeek.Saturday);

        public static bool IsWeekend(this DateTime dateTime) => !IsWorkday(dateTime);

    }
    #endregion

    class Program
    {
        static void Main()
        {


            Console.WriteLine("IS WEEKEND DATE");
            Console.WriteLine(new DateTime(2022, 01, 8).IsWeekend());
            Console.WriteLine(new DateTime(2022, 01, 11).IsWeekend());

            Console.WriteLine("IS WORKDAY");
            Console.WriteLine(new DateTime(2022, 01, 8).IsWorkday());
            Console.WriteLine(new DateTime(2022, 01, 11).IsWorkday());



            var list = new List<int> {1, 2, 3, 5, 6, 8, 9, 10,11,13 };
            var chunks = CollectionExtention<int>.ChunkBy(list, 2);
            foreach (var chunk in chunks)
            {
                Console.Write("array ");
                ShowAll<int>(chunk);
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
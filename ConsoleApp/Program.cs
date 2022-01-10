using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;


namespace ConsoleApp
{

    static class DateExtention
    {
        public static bool IsWorkday(this DateTime date)
        {
            return ((IsWeekend(date) != true) ? true : false);

        }
        public static bool IsWeekend(this DateTime date)
        {
            return (((date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday)) ? true : false);
        }
    }
    static class CollectionExtention<T>
    {
        public static List<List<T>> ChunkBy<T>(List<T> list, int itemsInList)
        {
            var newList = new List<List<T>>();

            PrintInputData(list);

            for (int i = 0; i < list.Count; i += itemsInList)
            {
                newList.Add(list.GetRange(i, Math.Min(itemsInList, list.Count - i)));
            }

            PrintOutData(newList);

            return newList;
        }
        public static void PrintInputData<T>(List<T> list)
        {
            Console.Write("Input List: ");
            foreach (T item in list)
            {
                Console.Write("[{0}] ", item);
            }
            Console.Write("\r\n");
        }
        private static void PrintOutData<T>(List<List<T>> _stringChunks)
        {
            for (int i = 0; i < _stringChunks.Count; i++)
            {
                Console.Write("[{0}] [ ", i);
                foreach (T item in _stringChunks[i])
                {
                    Console.Write("{0} ", item);
                }
                Console.Write("] \r\n");
            }
            Console.Write("\r\n");
        }
    }
    class ConsoleApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/homework/18-Extentions \r\n");

            DateTime dt = DateTime.Now;
            Console.WriteLine("DateTime Now: {0}", dt.ToString());
            Console.WriteLine("Is WorkDay? - {0}", DateExtention.IsWorkday(dt));
            Console.WriteLine("Is Weekend? - {0}\r\n", DateExtention.IsWeekend(dt));

            CollectionExtention<string>.ChunkBy(new List<string> { "str1", "str2", "str3", "str4", "str5" }, 2);
            CollectionExtention<int>.ChunkBy(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 2);
        }
    }
}

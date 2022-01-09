using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public static class DateTimeExtentions
    {
        public static bool IsWeekend(this DateTime checkDate) => checkDate.DayOfWeek == DayOfWeek.Saturday || checkDate.DayOfWeek == DayOfWeek.Sunday;

        public static bool IsWorkday(this DateTime checkDate) => !IsWeekend(checkDate); 
    }

    public static class IEnumerableExtentions
    {
        public static IEnumerable<IEnumerable<T>> ChunkBy<T>(this List<T> collection, int size)
        {
            var resultList = new List<List<T>>();


            for (int i = 0; i < collection.Count - collection.Count % size; i += size)
            {
                var elementResultList = new List<T>();
                for (int j = 0; j < size; j++)
                {
                    elementResultList.Add(collection[i + j]);
                }

                resultList.Add(elementResultList);
            }

            if (collection.Count % size != 0)
            {

                var elementResultList = new List<T>();

                for (int i = collection.Count - collection.Count % size; i < collection.Count; ++i)
                {
                    elementResultList.Add(collection[i]);
                }

                resultList.Add(elementResultList);
            }

            return resultList;
        }
    }

    public class Program
    {
        static void Main()
        {
            List<int> listInt = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            var listChunk = listInt.ChunkBy<int>(3);

            foreach (var item in listChunk)
            {
                foreach (var element in item)
                {
                    Console.Write($"{element} ");
                }
                Console.WriteLine();
            }
        }
    }    
}
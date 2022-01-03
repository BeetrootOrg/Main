using static System.Console;

namespace Course
{

    static class DateExtention
    {
        public static bool IsWeekend (this DateTime date)
        {
            return (date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday);
        }

        public static bool IsWorkday (this DateTime date)
        {
            return (date.DayOfWeek != DayOfWeek.Saturday) && (date.DayOfWeek != DayOfWeek.Sunday);
        }
    }

    static class CollectionExtention<T>
    {
        public static List<List<T>> ChunkBy(List<T> list, int itemsInList)
        {
            var newList = new List<List<T>>();
            for (int i = 0; i < list.Count; i += itemsInList)
            {
                newList.Add(list.GetRange(i, Math.Min(itemsInList, list.Count - i)));
            }

            return newList;
        }
    }

    class Program
    {
        static void Main()
        {
            var list = new List<int>{ 1,2,3,4,5,6,7,8,9,10 };
            var chunks = CollectionExtention<int>.ChunkBy(list, 3);
            foreach (var chunk in chunks)
            {
                Console.WriteLine("New chunk");
                ShowAll<int>(chunk);
            }
        }

        public static void ShowAll<T>(List<T> list)
        {
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }
    }    
}

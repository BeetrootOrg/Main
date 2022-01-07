using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18EXTANTION
{
    public static class Extantion
    {
        public static bool IsWeekend(this DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday) return true;

            return false;
        }
        public static bool IsWorkday(this DateTime date)
        {
            return !date.IsWeekend();
        }
        public static T[][] ChunkBy<C, T>(this C collection, int size) where C : ICollection<T>
        {
            var result = new T[Convert.ToInt32(Math.Ceiling((decimal)collection.Count / size))][];
            var tempList = collection.ToList();
            var temp = new T[size];
            for (int i = 0; i < collection.Count; i++)
            {
                if (temp.Count(x => !x.Equals(0)) == size)
                {
                    int max = result.Count(x => x!=null);
                    result[max] = temp;
                    temp = new T[size];
                }
                for (int j = 0; j < temp.Count(); j++)
                {
                    temp[j] = tempList[i];
                }
            }
            int lastMax = result.Count(x => x!=null);
            result[lastMax] = temp;
            return result;
        }
    }
}

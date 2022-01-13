using System;
using System.Collections;

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

    class Program
    {
        
        static void Main()
        {
            

        }

    }

}
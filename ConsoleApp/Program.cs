using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    static class DateTimeExtensions
    {


        public static bool IsWorkday(this DateTime dateTime) => dateTime.DayOfWeek switch
        {
            DayOfWeek.Sunday => true,
            DayOfWeek.Saturday => true,
            _ => false,
        };

        public static bool IsWeekend(this DateTime dateTime) => dateTime.DayOfWeek switch
        {
            DayOfWeek.Sunday => false,
            DayOfWeek.Saturday => false,
            _ => true,
        };


    }

    class Program
    {
        static void Main()
        {


            Console.WriteLine("IS WEEKEND DATE");
            Console.WriteLine(new DateTime(2022,01,8).IsWeekend());
            Console.WriteLine(new DateTime(2022,01,11).IsWeekend());

            Console.WriteLine("IS WORKDAY");
            Console.WriteLine(new DateTime(2022,01,8).IsWorkday());
            Console.WriteLine(new DateTime(2022,01,11).IsWorkday());


        }


    }
}
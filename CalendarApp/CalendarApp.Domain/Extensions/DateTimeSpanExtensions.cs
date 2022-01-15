
using CalendarApp.Contracts.Models;
using System;

namespace CalendarApp.Domain.Extensions
{
    internal static class DateTimeSpanExtensions
    {
        public static bool Inside(this DateTimeSpan dateTimeSpan, DateTime dateTime,
            bool includeStart = false,
            bool includeEnd = false) =>
            (dateTimeSpan.Start < dateTime || includeStart && dateTimeSpan.Start == dateTime) &&
            (dateTimeSpan.End > dateTime || includeEnd && dateTimeSpan.End == dateTime);
    }
}

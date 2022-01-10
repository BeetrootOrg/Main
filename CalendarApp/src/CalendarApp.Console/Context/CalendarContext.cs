using CalendarApp.Contracts.Models;
using System.Collections.Generic;

namespace CalendarApp.Console.Context
{
    internal class CalendarContext
    {
        public IList<Meeting> Meetings { get; private set; } = new List<Meeting>();
    }
}

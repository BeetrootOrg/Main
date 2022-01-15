using System;

namespace CalendarApp.Contracts.Models
{
    public record Meeting(string Name, DateTime StartAt, TimeSpan Duration, Room Room)
    {
        public DateTime EndAt => StartAt.Add(Duration);
        public DateTimeSpan DateTimeSpan => new(StartAt, EndAt);
    }
}

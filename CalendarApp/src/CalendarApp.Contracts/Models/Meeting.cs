using System;

namespace CalendarApp.Contracts.Models
{
    public record Meeting
    {
        public string Name { get; init; }
        public DateTime StartAt { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime EndAt => StartAt.Add(Duration);
        public Room Room { get; set; }
    }
}

using System;

namespace CalendarApp.Console.Models
{
    public class MeetingDto
    {
        public string Name { get; set; }
        public DateTime StartAt { get; set; }
        public TimeSpan Duration { get; set; }
        public string RoomName { get; set; }
        public int Id { get; init; }
    }
}

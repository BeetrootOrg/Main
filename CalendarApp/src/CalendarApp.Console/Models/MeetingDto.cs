using CalendarApp.Contracts.Models;
using MessagePack;
using System;

namespace CalendarApp.Console.Models
{
    [MessagePackObject]
    public class MeetingDto
    {
        [Key(0)]
        public string Name { get; set; }

        [Key(1)]
        public DateTime StartAt { get; set; }

        [Key(2)]
        public TimeSpan Duration { get; set; }

        [Key(3)]
        public string RoomName { get; set; }
    }
}

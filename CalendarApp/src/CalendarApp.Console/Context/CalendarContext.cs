using CalendarApp.Console.Models;
using CalendarApp.Contracts.Models;
using MessagePack;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace CalendarApp.Console.Context
{
    internal class CalendarContext
    {
        public IList<Meeting> Meetings { get; private set; } = new List<Meeting>();

        public void ReadFromFile(string filename)
        {
            var bytes = File.ReadAllBytes(filename);
            var meetings = MessagePackSerializer.Deserialize<IEnumerable<MeetingDto>>(bytes);

            Meetings = meetings.Select(meeting => new Meeting
            {
                Duration = meeting.Duration,
                Name = meeting.Name,
                Room = new Room
                {
                    Name = meeting.RoomName
                },
                StartAt = meeting.StartAt
            }).ToList();
        }

        public void WriteToFile(string filename)
        {
            var bytes = MessagePackSerializer.Serialize(Meetings.Select(meeting => new MeetingDto
            {
                StartAt = meeting.StartAt,
                RoomName = meeting.Room.Name,
                Name = meeting.Name,
                Duration = meeting.Duration
            }));

            File.WriteAllBytes(filename, bytes);
        }
    }
}

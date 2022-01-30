using CalendarApp.Console.Models;
using CalendarApp.Contracts.Models;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace CalendarApp.Console.Context
{
    internal class CalendarContext
    {
        public IList<Meeting> Meetings { get; private set; } = new List<Meeting>();

        public void ReadFromFile(string filename)
        {
            var text = File.ReadAllText(filename);
            var meetings = JsonConvert.DeserializeObject<IEnumerable<MeetingDto>>(text);

            Meetings = meetings
                .Select(meeting => 
                    new Meeting(meeting.Name, meeting.StartAt, meeting.Duration, new Room(meeting.RoomName)))
                .ToList();
        }

        public void WriteToFile(string filename)
        {
            var text = JsonConvert.SerializeObject(Meetings.Select(meeting => new MeetingDto
            {
                StartAt = meeting.StartAt,
                RoomName = meeting.Room.Name,
                Name = meeting.Name,
                Duration = meeting.Duration
            }));

            File.WriteAllText(filename, text);
        }
    }
}

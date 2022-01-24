using CalendarApp.Contracts.Models;
using CalendarApp.Domain.Extensions;
using CalendarApp.Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CalendarApp.Domain.Services
{
    internal class MeetingService : IMeetingService
    {
        public Meeting FindByName(IEnumerable<Meeting> meetings, string meetingName) =>
            meetings.SingleOrDefault(meeting => meeting.Name == meetingName);

        public bool IsNameUnique(IEnumerable<Meeting> meetings, string meetingName) =>
            meetings.All(meeting => meeting.Name != meetingName);

        public bool OverlapWithAny(IEnumerable<Meeting> meetings, Meeting meeting) => 
            meetings.Where(m => m.Room.Equals(meeting.Room))
                .Any(m =>
                {
                    var first = meeting.DateTimeSpan;
                    var second = m.DateTimeSpan;

                    return first.Inside(m.StartAt, true, false) ||
                        second.Inside(meeting.StartAt, true, false);
                });
    }
}

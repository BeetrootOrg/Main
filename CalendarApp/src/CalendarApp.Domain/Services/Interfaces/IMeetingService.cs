using CalendarApp.Contracts.Models;
using System.Collections.Generic;

namespace CalendarApp.Domain.Services.Interfaces
{
    public interface IMeetingService
    {
        bool OverlapWithAny(IEnumerable<Meeting> meetings, Meeting meeting);

        bool UniqueName(IEnumerable<Meeting> meetings, Meeting meeting);

        IList<Meeting> DeleteMeeting(IEnumerable<Meeting> meetings, string meetingName);

        int FindMeeting(IEnumerable<Meeting> meetings, string meetingName);
    }
}

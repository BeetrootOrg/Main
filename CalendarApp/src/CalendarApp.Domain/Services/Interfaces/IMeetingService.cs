using CalendarApp.Contracts.Models;
using System.Collections.Generic;

namespace CalendarApp.Domain.Services.Interfaces
{
    public interface IMeetingService
    {
        bool OverlapWithAny(IEnumerable<Meeting> meetings, Meeting meeting);
        bool IsUniqueName(IEnumerable<Meeting> meetings, Meeting meeting);
        int FindMeeting(IEnumerable<Meeting> meetings, string meetingName);
    }
}
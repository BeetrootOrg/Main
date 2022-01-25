using CalendarApp.Contracts.Models;
using System.Collections.Generic;

namespace CalendarApp.Domain.Services.Interfaces
{
    public interface IMeetingService
    {
        bool OverlapWithAny(IEnumerable<Meeting> meetings, Meeting meeting);
        bool IsNameUniq(IEnumerable<Meeting> meetings, string meetingName);
    }
}
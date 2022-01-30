using CalendarApp.Contracts.Models;
using System.Collections.Generic;

namespace CalendarApp.Domain.Services.Interfaces
{
    public interface IMeetingService
    {
        Meeting Create(string name, DateTime start, TimeSpan duration, string roomName);
        Meeting Update(Meeting meeting, DateTime start, TimeSpan duration, string roomName);
        bool OverlapWithAny(IEnumerable<Meeting> meetings, Meeting meeting);
    }
}
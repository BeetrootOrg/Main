using CalendarApp.Contracts.Models;
using System;

namespace CalendarApp.Domain.Services.Interfaces
{
    public interface IMeetingService
    {
        Meeting Create(string name, DateTime start, TimeSpan duration, string roomName);
        Meeting Update(Meeting meeting, DateTime start, TimeSpan duration, string roomName);
    }
}
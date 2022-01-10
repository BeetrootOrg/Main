using CalendarApp.Contracts.Models;
using CalendarApp.Domain.Services.Interfaces;
using System;

namespace CalendarApp.Domain.Services
{
    internal class MeetingService : IMeetingService
    {
        public Meeting Create(string name, DateTime start, TimeSpan duration, string roomName)
        {
            return new Meeting
            {
                Duration = duration,
                Room = new Room
                {
                    Name = roomName,
                },
                Name = name,
                StartAt = start
            };
        }
    }
}

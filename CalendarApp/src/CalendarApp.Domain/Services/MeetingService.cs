using CalendarApp.Contracts.Models;
using System;

namespace CalendarApp.Domain.Services
{
    internal class MeetingService
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

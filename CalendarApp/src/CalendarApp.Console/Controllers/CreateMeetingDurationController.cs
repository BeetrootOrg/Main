using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Services;
using System;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingDurationController : IController
    {
        private readonly string _meetingName;
        private readonly DateTime _startAt;

        public CreateMeetingDurationController(string meetingName, DateTime startAt)
        {
            _meetingName = meetingName;
            _startAt = startAt;
        }

        public IController Action()
        {
            var input = ReadLine();

            if (int.TryParse(input, out var minutes))
            {
                return new CreateMeetingController(new MeetingService(), 
                    _meetingName, 
                    _startAt, 
                    TimeSpan.FromMinutes(minutes));
            }

            return this;
        }

        public void Render()
        {
            WriteLine("Enter meeting duration (in minutes):");
        }
    }
}

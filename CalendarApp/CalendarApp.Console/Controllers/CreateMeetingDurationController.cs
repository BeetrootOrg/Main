using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using System;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingDurationController : IController
    {
        private readonly CalendarContext _calendarContext;

        private readonly string _meetingName;
        private readonly DateTime _startAt;

        public CreateMeetingDurationController(CalendarContext calendarContext, string meetingName, DateTime startAt)
        {
            _calendarContext = calendarContext;
            _meetingName = meetingName;
            _startAt = startAt;
        }

        public IController Action()
        {
            var input = ReadLine();

            if (int.TryParse(input, out var minutes))
            {
                return new CreateMeetingRoomController(_calendarContext,
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
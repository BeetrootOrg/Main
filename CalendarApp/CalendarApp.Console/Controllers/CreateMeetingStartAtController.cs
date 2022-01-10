using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using System;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingStartAtController : IController
    {
        private readonly CalendarContext _calendarContext;

        private readonly string _meetingName;

        public CreateMeetingStartAtController(CalendarContext calendarContext, string meetingName)
        {
            _calendarContext = calendarContext;
            _meetingName = meetingName;
        }

        public IController Action()
        {
            var input = ReadLine();

            if (DateTime.TryParse(input, out var startAt))
            {
                return new CreateMeetingDurationController(_calendarContext, _meetingName, startAt);
            }

            return this;
        }

        public void Render()
        {
            WriteLine("Enter start datetime:");
        }
    }
}

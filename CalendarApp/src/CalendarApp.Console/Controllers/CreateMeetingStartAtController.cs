using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Builders;
using System;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingStartAtController : IController
    {
        private readonly CalendarContext _calendarContext;
        private readonly MeetingBuilder _meetingBuilder;

        public CreateMeetingStartAtController(CalendarContext calendarContext, MeetingBuilder meetingBuilder)
        {
            _calendarContext = calendarContext;
            _meetingBuilder = meetingBuilder;
        }

        public IController Action()
        {
            var input = ReadLine();

            try
            {
                _meetingBuilder.SetMeetingStartAt(input);
                return new CreateMeetingDurationController(_calendarContext, _meetingBuilder);
            }
            catch (ArgumentException)
            {
                return this;
            }
        }

        public void Render()
        {
            WriteLine("Enter start datetime:");
        }
    }
}

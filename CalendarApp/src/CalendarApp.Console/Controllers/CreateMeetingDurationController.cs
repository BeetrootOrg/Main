using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Builders;
using System;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingDurationController : IController
    {
        private readonly CalendarContext _calendarContext;
        private readonly MeetingBuilder _meetingBuilder;
        private readonly NameMode _mode;

        public CreateMeetingDurationController(CalendarContext calendarContext, MeetingBuilder meetingBuilder)
        {
            _calendarContext = calendarContext;
            _meetingBuilder = meetingBuilder;
            _mode = new NameMode();
            _mode.nameMode = Mode.CreateName;
        }
        public CreateMeetingDurationController(CalendarContext calendarContext, MeetingBuilder meetingBuilder, NameMode mode)
        {
            _calendarContext = calendarContext;
            _meetingBuilder = meetingBuilder;
            _mode = new NameMode();
            _mode = mode;
        }

        public IController Action()
        {
            var input = "0";

            if (_mode.nameMode != Mode.DeleteName)
            {
                input = ReadLine();
            }

            try
            {
                _meetingBuilder.SetMeetingDuration(input);
                // return new CreateMeetingRoomController(_calendarContext, _meetingBuilder);
                return new CreateMeetingRoomController(_calendarContext, _meetingBuilder, _mode);
            }
            catch (ArgumentException)
            {
                return this;
            }
        }

        public void Render()
        {
            if (_mode.nameMode != Mode.DeleteName) { WriteLine("Enter meeting duration (in minutes):"); }
        }
    }
}

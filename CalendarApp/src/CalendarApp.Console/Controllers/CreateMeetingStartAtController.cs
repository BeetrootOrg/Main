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
        private readonly NameMode _mode;

        public CreateMeetingStartAtController(CalendarContext calendarContext, MeetingBuilder meetingBuilder)
        {
            _calendarContext = calendarContext;
            _meetingBuilder = meetingBuilder;
            _mode = new NameMode();
            _mode.nameMode = Mode.CreateName;
        }
        public CreateMeetingStartAtController(CalendarContext calendarContext, MeetingBuilder meetingBuilder, NameMode mode)
        {
            _calendarContext = calendarContext;
            _meetingBuilder = meetingBuilder;
            _mode = new NameMode();
            _mode = mode;
        }
        public IController Action()
        {
            var input = ReadLine();

            try
            {
                _meetingBuilder.SetMeetingStartAt(input);
                // return new CreateMeetingDurationController(_calendarContext, _meetingBuilder);
                return new CreateMeetingDurationController(_calendarContext, _meetingBuilder, _mode);
            }
            catch (ArgumentException)
            {
                return this;
            }
        }

        public void Render()
        {
            if (_mode.nameMode != Mode.DeleteName) { WriteLine("Enter start datetime:"); }
        }
    }
}

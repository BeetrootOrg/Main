using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Builders;
using CalendarApp.Domain.Factories;
using System;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingRoomController : IController
    {
        private readonly CalendarContext _calendarContext;
        private readonly MeetingBuilder _meetingBuilder;
        private readonly NameMode _mode;

        public CreateMeetingRoomController(CalendarContext calendarContext, MeetingBuilder meetingBuilder)
        {
            _calendarContext = calendarContext;
            _meetingBuilder = meetingBuilder;
            _mode = new NameMode();
            _mode.nameMode = Mode.CreateName;
        }
        public CreateMeetingRoomController(CalendarContext calendarContext, MeetingBuilder meetingBuilder, NameMode mode)
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
                _meetingBuilder.SetMeetingRoom(input);
                /*return new CreateMeetingController(Factory.CreateMeetingService(),
                    _calendarContext,
                    _meetingBuilder);*/
                return new CreateMeetingController(Factory.CreateMeetingService(),
                    _calendarContext,
                    _meetingBuilder,
                    _mode);
            }
            catch (ArgumentException)
            {
                return this;
            }
        }

        public void Render()
        {
            WriteLine("Enter room name:");
        }
    }
}

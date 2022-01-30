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

        public CreateMeetingRoomController(CalendarContext calendarContext, MeetingBuilder meetingBuilder)
        {
            _calendarContext = calendarContext;
            _meetingBuilder = meetingBuilder;
        }

        public IController Action()
        {
            var input = ReadLine();

            try
            {
                _meetingBuilder.SetMeetingRoom(input);
                return new CreateMeetingController(Factory.CreateMeetingService(),
                    _calendarContext,
                    _meetingBuilder);
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

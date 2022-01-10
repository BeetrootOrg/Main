using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Factories;
using System;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingRoomController : IController
    {
        private readonly CalendarContext _calendarContext;

        private readonly string _meetingName;
        private readonly DateTime _startAt;
        private readonly TimeSpan _duration;

        public CreateMeetingRoomController(CalendarContext calendarContext,
            string meetingName, DateTime startAt, TimeSpan duration)
        {
            _calendarContext = calendarContext;
            _meetingName = meetingName;
            _startAt = startAt;
            _duration = duration;
        }

        public IController Action()
        {
            var input = ReadLine();

            return new CreateMeetingController(Factory.CreateMeetingService(),
                _calendarContext,
                _meetingName,
                _startAt,
                _duration,
                input);
        }

        public void Render()
        {
            WriteLine("Enter room name:");
        }
    }
}

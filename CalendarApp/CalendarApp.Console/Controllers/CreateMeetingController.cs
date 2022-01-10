using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Services.Interfaces;
using System;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingController : IController
    {
        private readonly IMeetingService _meetingService;
        private readonly CalendarContext _calendarContext;

        private readonly string _meetingName;
        private readonly DateTime _startAt;
        private readonly TimeSpan _duration;
        private readonly string _roomName;

        public CreateMeetingController(IMeetingService meetingService, CalendarContext calendarContext,
            string meetingName, DateTime startAt, TimeSpan duration, string roomName)
        {
            _meetingService = meetingService;
            _calendarContext = calendarContext;
            _meetingName = meetingName;
            _startAt = startAt;
            _duration = duration;
            _roomName = roomName;
        }

        public IController Action()
        {
            var meeting = _meetingService.Create(_meetingName, _startAt, _duration, _roomName);
            _calendarContext.Meetings.Add(meeting);
            return new MainMenuController(_calendarContext);
        }

        public void Render()
        {
        }
    }
}
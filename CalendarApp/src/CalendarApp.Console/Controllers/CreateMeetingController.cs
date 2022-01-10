using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Services;
using System;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingController : IController
    {
        private readonly MeetingService _meetingService;
        private readonly CalendarContext _calendarContext;

        private readonly string _meetingName;
        private readonly DateTime _startAt;
        private readonly TimeSpan _duration;

        public CreateMeetingController(MeetingService meetingService, CalendarContext calendarContext, 
            string meetingName, DateTime startAt, TimeSpan duration)
        {
            _meetingService = meetingService;
            _calendarContext = calendarContext;
            _meetingName = meetingName;
            _startAt = startAt;
            _duration = duration;
        }

        public IController Action()
        {
            var meeting = _meetingService.Create(_meetingName, _startAt, _duration, "ToDo: rename me");
            _calendarContext.Meetings.Add(meeting);
            return new MainMenuController(_calendarContext);
        }

        public void Render()
        {
        }
    }
}

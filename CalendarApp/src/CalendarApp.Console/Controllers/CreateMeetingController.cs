using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Services;
using System;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingController : IController
    {
        private readonly MeetingService _meetingService;

        private readonly string _meetingName;
        private readonly DateTime _startAt;
        private readonly TimeSpan _duration;

        public CreateMeetingController(MeetingService meetingService, string meetingName, DateTime startAt, TimeSpan duration)
        {
            _meetingService = meetingService;
            _meetingName = meetingName;
            _startAt = startAt;
            _duration = duration;
        }

        public IController Action()
        {
            var meeting = _meetingService.Create(_meetingName, _startAt, _duration, "ToDo: rename me");
            return new MainMenuController();
        }

        public void Render()
        {
        }
    }
}

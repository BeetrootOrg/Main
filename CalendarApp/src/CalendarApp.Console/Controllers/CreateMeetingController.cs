using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Builders;
using CalendarApp.Domain.Services.Interfaces;
using System;
using System.Linq;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingController : IController
    {
        private readonly IMeetingService _meetingService;
        private readonly CalendarContext _calendarContext;
        private readonly MeetingBuilder _meetingBuilder;

        public CreateMeetingController(IMeetingService meetingService, CalendarContext calendarContext, 
            MeetingBuilder meetingBuilder)
        {
            _meetingService = meetingService;
            _calendarContext = calendarContext;
            _meetingBuilder = meetingBuilder;
        }

        public IController Action()
        {
            try
            {
                var meeting = _meetingBuilder.Build();

                if (_meetingService.OverlapWithAny(_calendarContext.Meetings, meeting))
                {
                    return new CreateMeetingOverlapController(_calendarContext);
                }

                var existingMeet = _calendarContext.Meetings.FirstOrDefault(m => m.Name == meeting.Name);

                if (meeting != null)
                {
                    _calendarContext.Meetings.Remove(existingMeet);
                }

                _calendarContext.Meetings.Add(meeting);
                return new MainMenuController(_calendarContext);
            }
            catch (ArgumentNullException)
            {
                return new MainMenuController(_calendarContext);
            }
        }

        public void Render()
        {
        }
    }
}

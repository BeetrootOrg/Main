using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Builders;
using CalendarApp.Domain.Services.Interfaces;
using System;

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
                _meetingBuilder.SetMeetingIndex(_calendarContext.Meetings.Count);
                var meeting = _meetingBuilder.Build();
                var meetingId = _meetingService.FindMeeting(_calendarContext.Meetings, meeting.Name);

                if (!_meetingService.UniqueName(_calendarContext.Meetings, meeting) && meeting.Id != meetingId)
                {
                    return new CreateMeetingUniqueNameController(_calendarContext);
                }
                if (_meetingService.OverlapWithAny(_calendarContext.Meetings, meeting))
                {
                    return new CreateMeetingOverlapController(_calendarContext);
                }

                if (meetingId != -1)
                {
                    _calendarContext.Meetings[meetingId] = meeting;
                } else
                {
                    _calendarContext.Meetings.Add(meeting);
                }
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

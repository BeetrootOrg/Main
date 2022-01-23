using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Builders;
using CalendarApp.Domain.Services.Interfaces;
using System;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class EditMeetingController : IController
    {
        private readonly CalendarContext _calendarContext;
        private readonly MeetingBuilder _meetingBuilder;
        private readonly IMeetingService _meetingService;
        public EditMeetingController(IMeetingService meetingService, CalendarContext calendarContext, MeetingBuilder meetingBuilder)
        {
            _meetingService = meetingService;
            _calendarContext = calendarContext;
            _meetingBuilder = meetingBuilder;
        }

        public IController Action()
        {
            var input = ReadLine();
            try
            {
                var meetingIndex = _meetingService.FindMeeting(_calendarContext.Meetings, input);
                if (meetingIndex == -1)
                {
                    return new NoMeetingFoundController(_calendarContext);
                }

                _meetingBuilder.SetMeetingName(_calendarContext.Meetings[meetingIndex].Name);
                _meetingBuilder.SetUpdateMeeting(true);
                return new CreateMeetingStartAtController(_calendarContext, _meetingBuilder);
            }
            catch (ArgumentException)
            {
                return new MainMenuController(_calendarContext);
            }
        }

        public void Render()
        {
            Clear();
            WriteLine("Enter meeting name to edit:");
        }
    }
}

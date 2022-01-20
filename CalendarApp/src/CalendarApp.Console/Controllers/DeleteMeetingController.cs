using System;
using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Services.Interfaces;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class DeleteMeetingController : IController
    {
        private readonly CalendarContext _calendarContext;
        private readonly IMeetingService _meetingService;

        public DeleteMeetingController(IMeetingService meetingService, CalendarContext calendarContext)
        {
            _meetingService = meetingService;
            _calendarContext = calendarContext;
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
                var updatedMeetings = _meetingService.DeleteMeeting(_calendarContext.Meetings, input);
                _calendarContext.SetNewMeetingsList(updatedMeetings);
                return new MainMenuController(_calendarContext);
            }
            catch (ArgumentException)
            {
                return this;
            }
        }

        public void Render()
        {
            Clear();
            WriteLine("Enter meeting name to delete:");
        }
    }
}

using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Services.Interfaces;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class DeleteMeetingByNameController : IController
    {
        private readonly CalendarContext _calendarContext;
        private readonly IMeetingService _meetingService;

        public DeleteMeetingByNameController(CalendarContext calendarContext, IMeetingService meetingService)
        {
            _calendarContext = calendarContext;
            _meetingService = meetingService;
        }

        public IController Action()
        {
            var input = ReadLine();
            var meeting = _meetingService.FindByName(_calendarContext.Meetings, input);

            if (meeting != null)
            {
                _calendarContext.Meetings.Remove(meeting);
            }

            return new MainMenuController(_calendarContext);
        }

        public void Render()
        {
            WriteLine("Enter meeting name to delete:");
        }
    }
}

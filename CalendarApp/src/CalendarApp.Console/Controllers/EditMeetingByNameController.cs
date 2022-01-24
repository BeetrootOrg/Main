using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Builders;
using CalendarApp.Domain.Services.Interfaces;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class EditMeetingByNameController : IController
    {
        private readonly CalendarContext _calendarContext;
        private readonly IMeetingService _meetingService;

        public EditMeetingByNameController(CalendarContext calendarContext, IMeetingService meetingService)
        {
            _calendarContext = calendarContext;
            _meetingService = meetingService;
        }

        public IController Action()
        {
            var input = ReadLine();

            var meeting = _meetingService.FindByName(_calendarContext.Meetings, input);

            if (meeting == null)
            {
                return new MainMenuController(_calendarContext);
            }

            var meetingBuilder = new MeetingBuilder()
                .SetMeetingName(input);

            return new CreateMeetingStartAtController(_calendarContext, meetingBuilder);
        }

        public void Render()
        {
            WriteLine("Enter meeting name:");
        }
    }
}

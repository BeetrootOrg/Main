using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Factories;
using CalendarApp.Domain.Services.Interfaces;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class DeleteMeetingController:IController
    {
        private readonly CalendarContext _calendarContext;
        private readonly IMeetingService _meetingService;

        public DeleteMeetingController(CalendarContext calendarContext)
        {
            _calendarContext = calendarContext;
        }

        public IController Action()
        {
            var input = ReadLine();
            var _meetingService = Factory.CreateMeetingService();
            try
            {
                var meetingToDelete = _meetingService.FindMeeting(_calendarContext.Meetings, input);
                _calendarContext.Meetings.RemoveAt(meetingToDelete);
                return new MainMenuController(_calendarContext);
            }
            catch
            {
                return this;
            }

        }

        public void Render()
        {
            WriteLine("Please enter of meeting which you would like to delete");
        }
    }
}
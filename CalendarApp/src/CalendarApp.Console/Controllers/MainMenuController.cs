using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Builders;
using CalendarApp.Domain.Factories;
using CalendarApp.Domain.Services.Interfaces;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class MainMenuController : IController
    {
        private readonly CalendarContext _calendarContext;
        private readonly IMeetingService _meetingService;

        public MainMenuController(CalendarContext calendarContext)
        {
            _calendarContext = calendarContext;

        }

        public IController Action()
        {
            var input = ReadLine();

            return input switch
            {
                "1" => new CreateMeetingNameController(_calendarContext, new MeetingBuilder()),
                "2" => new ShowAllMeetingsController(_calendarContext),
                "3" => new EditMeetingController(Factory.CreateMeetingService(), _calendarContext,new MeetingBuilder()),
                "4" => new DeleteMeetingController(_calendarContext),
                "0" => null,
                _ => this,
            };
        }

        public void Render()
        {
            Clear();
            WriteLine("1. Add meeting");
            WriteLine("2. Show all meetings");
            WriteLine("3. Edit meeting by name");
            WriteLine("4. Delete meeting by name");
            WriteLine("0. Exit");
        }
    }
}

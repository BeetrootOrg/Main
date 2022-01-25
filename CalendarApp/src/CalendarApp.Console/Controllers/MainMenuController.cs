using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Builders;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class MainMenuController : IController
    {
        private readonly CalendarContext _calendarContext;

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
                "3" => new DeleteMeetingByName(_calendarContext),
                "4" => new EditElementByName(_calendarContext),
                "0" => null,
                _ => this,
            };
        }

        public void Render()
        {
            Clear();
            WriteLine("1. Add meeting");
            WriteLine("2. Show all meetings");
            WriteLine("3. Delete by name");
            WriteLine("4. Edit by name");
            WriteLine("0. Exit");
        }
    }
}

using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingOverlapController : IController
    {
        private readonly CalendarContext _calendarContext;

        public CreateMeetingOverlapController(CalendarContext calendarContext)
        {
            _calendarContext = calendarContext;
        }

        public IController Action()
        {
            ReadLine();
            return new MainMenuController(_calendarContext);
        }

        public void Render()
        {
            WriteLine("Meeting overlaps with another one");
            WriteLine("To continue press Enter...");
        }
    }
}

using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class NoMeetingFoundController : IController
    {
        private readonly CalendarContext _calendarContext;

        public NoMeetingFoundController(CalendarContext calendarContext)
        {
            _calendarContext = calendarContext;
        }

        public IController Action()
        {
            ReadKey();

            return new MainMenuController(_calendarContext);
        }

        public void Render()
        {
            Clear();
            WriteLine("No meeting was found");
        }
    }
}

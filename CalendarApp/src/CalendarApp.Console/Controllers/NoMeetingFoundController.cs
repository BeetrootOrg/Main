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
            var input = ReadLine();
            return new MainMenuController(_calendarContext);
        }

        public void Render()
        {
            Clear();
            WriteLine("There is no meeting with that name");
            WriteLine("Press enter to go to back menu...");

        }
    }
}
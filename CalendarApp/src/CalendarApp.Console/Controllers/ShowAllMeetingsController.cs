using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class ShowAllMeetingsController : IController
    {
        private readonly CalendarContext _calendarContext;

        public ShowAllMeetingsController(CalendarContext calendarContext)
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
            Clear();

            foreach (var meeting in _calendarContext.Meetings)
            {
                WriteLine(meeting);
            }

            WriteLine("To continue press Enter...");
        }
    }
}

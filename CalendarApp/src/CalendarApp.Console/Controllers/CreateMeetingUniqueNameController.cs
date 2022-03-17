using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingUniqueNameController : IController
    {
        private readonly CalendarContext _calendarContext;

        public CreateMeetingUniqueNameController(CalendarContext calendarContext)
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
            WriteLine("Meeting doen't have the unique name");
            WriteLine("To continue press Enter...");
        }
    }
}

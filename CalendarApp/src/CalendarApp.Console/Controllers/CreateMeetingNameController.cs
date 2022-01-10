using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingNameController : IController
    {
        private readonly CalendarContext _calendarContext;

        public CreateMeetingNameController(CalendarContext calendarContext)
        {
            _calendarContext = calendarContext;
        }

        public IController Action()
        {
            var input = ReadLine();
            return new CreateMeetingStartAtController(_calendarContext, input);
        }

        public void Render()
        {
            WriteLine("Enter meeting name:");
        }
    }
}

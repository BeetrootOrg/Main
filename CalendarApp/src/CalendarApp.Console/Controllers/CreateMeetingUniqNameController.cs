using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers;
using CalendarApp.Console.Controllers.Interfaces;
using static System.Console;


namespace CalendarApp.Console
{
    internal class CreateMeetingUniqNameController : IController
    {
        private readonly CalendarContext _calendarContext;
        public CreateMeetingUniqNameController(CalendarContext calendarContext)
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
            WriteLine("Meeting name isn't unique.");
            WriteLine("Press Enter and go back to main menu");
        }
    }
}

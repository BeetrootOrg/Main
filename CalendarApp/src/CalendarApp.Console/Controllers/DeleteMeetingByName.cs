using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using System.Linq;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class DeleteMeetingByName : IController
    {
        private readonly CalendarContext _calendarContext;

        public DeleteMeetingByName(CalendarContext calendarContext)
        {
            _calendarContext = calendarContext;
        }

        IController IController.Action()
        {
            var input = ReadLine();

            var deleteMeet = _calendarContext.Meetings.FirstOrDefault(m => m.Name == input);

            if (deleteMeet != null)
            {
                _calendarContext.Meetings.Remove(deleteMeet);
            }

            return new MainMenuController(_calendarContext);
        }

        void IController.Render()
        {
            Clear();
            WriteLine("Write the Name of Delete meeting:");
        }
    }
}

using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Builders;
using System.Linq;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class EditElementByName : IController
    {
        private readonly CalendarContext _calendarContext;

        public EditElementByName(CalendarContext calendarContext)
        {
            _calendarContext = calendarContext;
        }

        IController IController.Action()
        {
            var input = ReadLine();
            var meet = _calendarContext.Meetings.FirstOrDefault(m => m.Name == input);

            if (meet == null)
            {
                return new MainMenuController(_calendarContext);
            }

            var meetingBuilder = new MeetingBuilder().SetMeetingName(input);

            return new CreateMeetingStartAtController(_calendarContext, meetingBuilder);
        }

        void IController.Render()
        {
            Clear();
            WriteLine("Write the Name of Edit meeting:");
        }
    }
}

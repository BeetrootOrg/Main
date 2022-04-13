using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Builders;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class EditMeetingController : IController
    {
        private readonly CalendarContext _calendarContext;

        public EditMeetingController(CalendarContext calendarContext)
        {
            _calendarContext = calendarContext;
        }

        public IController Action()
        {

            string input = ReadLine();
            int i=0;
            bool found = false;
            foreach (var element in _calendarContext.Meetings)
            {
            
                if (element.Name.Equals(input))
                {
                    found = true; break;
                }
                i++;

            }
            if (found)
            {
            MeetingBuilder meetingBuilder = new MeetingBuilder();
            meetingBuilder.SetMeetingName(input);

            return new CreateMeetingStartAtController(_calendarContext, meetingBuilder);
            }
            else
            {
                WriteLine($"Meeting with name {input} not found");
                return  new MainMenuController(_calendarContext);
            }
        }

        public void Render()
        {
            Clear();

            WriteLine("Enter the name of meeting You want to edit...");
        }
    }
}

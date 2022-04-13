using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Builders;
using System;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingNameController : IController
    {
        private readonly CalendarContext _calendarContext;
        private readonly MeetingBuilder _meetingBuilder;

        public CreateMeetingNameController(CalendarContext calendarContext, MeetingBuilder meetingBuilder)
        {
            _calendarContext = calendarContext;
            _meetingBuilder = meetingBuilder;
        }

        public IController Action()
        {
            var input = ReadLine();


            int i = 0;
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


                
                WriteLine($"Meeting {input} is already exists. Press enter to choose another name...");

                ReadLine();
                return this;
            }
            else
            {
                try
                {
                    _meetingBuilder.SetMeetingName(input);
                    return new CreateMeetingStartAtController(_calendarContext, _meetingBuilder);
                }
                catch (ArgumentException)
                {
                    return this;
                }

            }





        }

        public void Render()
        {
            Clear();
            WriteLine("Enter meeting name:");
        }
    }
}

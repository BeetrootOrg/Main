using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Builders;
using System;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class EditMeetingController : IController
    {
        private readonly CalendarContext _calendarContext;
        private Contracts.Models.Meeting _editCalendarContext;
        private readonly MeetingBuilder _meetingBuilder;

        public EditMeetingController(CalendarContext calendarContext, MeetingBuilder meetingBuilder)
        {
            _calendarContext = calendarContext;
            _meetingBuilder = meetingBuilder;
        }
        (bool, int) CheckInputName(string input)
        {
            for(int i = 0; i < _calendarContext.Meetings.Count; i++)
            {
                if (input == _calendarContext.Meetings[i].Name)
                {
                    _editCalendarContext = _calendarContext.Meetings[i];
                    return (true, i);
                }
            }
            _editCalendarContext = null;
            return (false, 0);
        }
        public IController Action()
        {
            var input = ReadLine();

            try
            {
                (bool, int) result = CheckInputName(input);
                if (result.Item1 == true)
                {                    
                    WriteLine("List has name \"{0}\" at index \"{1}\"", input, result.Item2);
                    WriteLine(_editCalendarContext);
                    _meetingBuilder.SetMeetingName(input);
                    return new CreateMeetingStartAtController(_calendarContext, _meetingBuilder, 
                        new NameMode { nameMode = Mode.EditName, index = result.Item2 });
                }
                WriteLine("List has not name \"{0}\", please enter another name!", input);
                WriteLine("To continue press Enter ...");
                ReadLine();
                return this;
            }
            catch (ArgumentException)
            {
                return this;
            }
        }
        public void Render()
        {
            Clear();
            WriteLine("Enter meeting name for \"Edit\":");
        }
    }
}

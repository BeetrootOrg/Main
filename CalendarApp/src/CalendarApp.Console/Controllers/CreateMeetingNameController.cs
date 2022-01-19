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
        bool CheckInputName(string input)
        {
            foreach (var meeting in _calendarContext.Meetings)
            {
                if (input == meeting.Name)
                {
                    WriteLine("The list already has the name \"{0}\", please enter another name", meeting.Name);
                    return true;
                }
            }
            return false;
        }
        public IController Action()
        {
            var input = ReadLine();

            try
            {
                if (CheckInputName(input) != true)
                {
                    _meetingBuilder.SetMeetingName(input);
                    return new CreateMeetingStartAtController(_calendarContext, _meetingBuilder);
                }
                {
                    WriteLine("To continue press Enter ...");
                    ReadLine();
                    return this;
                }
            }
            catch (ArgumentException)
            {
                return this;
            }
        }
        public void Render()
        {
            Clear();
            WriteLine("Enter meeting name:");
        }
    }
}

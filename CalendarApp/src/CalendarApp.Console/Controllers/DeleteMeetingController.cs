using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Builders;
using CalendarApp.Domain.Factories;
using System;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class DeleteMeetingController : IController
    {
        private readonly CalendarContext _calendarContext;
        private Contracts.Models.Meeting _deliteCalendarContext;
        private readonly MeetingBuilder _meetingBuilder;

        public DeleteMeetingController(CalendarContext calendarContext, MeetingBuilder meetingBuilder)
        {
            _calendarContext = calendarContext;
            _meetingBuilder = meetingBuilder;
        }
        (bool, int) CheckInputName(string input)
        {
            for (int i = 0; i < _calendarContext.Meetings.Count; i++)
            {
                if (input == _calendarContext.Meetings[i].Name)
                {
                    _deliteCalendarContext = _calendarContext.Meetings[i];
                    return (true, i);
                }
            }
            _deliteCalendarContext = null;
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
                    WriteLine(_deliteCalendarContext);
                    _meetingBuilder.SetMeetingName(input);

                    WriteLine("Delete \"{0}\" meeting? // type: \"yes\" or \"no\"", input);
                    input = ReadLine();

                    //return new CreateMeetingStartAtController(_calendarContext, _meetingBuilder,
                    //   new NameMode { nameMode = Mode.DeleteName, index = result.Item2 });
                    if (input == "yes")
                    {
                        return new CreateMeetingController(Factory.CreateMeetingService(), _calendarContext, _meetingBuilder,
                        new NameMode { nameMode = Mode.DeleteName, index = result.Item2 });
                    }
                        return new CreateMeetingController(Factory.CreateMeetingService(), _calendarContext, _meetingBuilder,
                        new NameMode { nameMode = Mode.DefaultName, index = 0 });
                }
                WriteLine("List has not name \"{0}\", please enter another name!", input);
                WriteLine("To continue press Enter ...");
                ReadLine();
                return new CreateMeetingController(Factory.CreateMeetingService(), _calendarContext, _meetingBuilder,
                        new NameMode { nameMode = Mode.DefaultName, index = 0 });
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
        public void Render()
        {
            Clear();
            WriteLine("Enter meeting name for \"Delete\":");
        }
    }
}

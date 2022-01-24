using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Builders;
using CalendarApp.Domain.Services.Interfaces;
using System;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingNameController : IController
    {
        private readonly CalendarContext _calendarContext;
        private readonly IMeetingService _meetingService;
        private readonly MeetingBuilder _meetingBuilder;

        public CreateMeetingNameController(CalendarContext calendarContext, 
            IMeetingService meetingService,
            MeetingBuilder meetingBuilder)
        {
            _calendarContext = calendarContext;
            _meetingService = meetingService;
            _meetingBuilder = meetingBuilder;
        }

        public IController Action()
        {
            var input = ReadLine();

            try
            {
                if (!_meetingService.IsNameUnique(_calendarContext.Meetings, input))
                {
                    return this;
                }

                _meetingBuilder.SetMeetingName(input);
                return new CreateMeetingStartAtController(_calendarContext, _meetingBuilder);
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

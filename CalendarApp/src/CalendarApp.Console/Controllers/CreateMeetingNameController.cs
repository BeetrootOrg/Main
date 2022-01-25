using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Builders;
using CalendarApp.Domain.Factories;
using CalendarApp.Domain.Services;
using CalendarApp.Domain.Services.Interfaces;
using System;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingNameController : IController
    {
        private readonly CalendarContext _calendarContext;
        private readonly MeetingBuilder _meetingBuilder;
        private readonly IMeetingService _meetingService = Factory.CreateMeetingService();

        public CreateMeetingNameController(CalendarContext calendarContext, MeetingBuilder meetingBuilder)
        {
            _calendarContext = calendarContext;
            _meetingBuilder = meetingBuilder;
        }

        public IController Action()
        {
            var input = ReadLine();

            try
            {
                if (_meetingService.IsNameUniq(_calendarContext.Meetings, input))
                {
                    _meetingBuilder.SetMeetingName(input);
                    return new CreateMeetingStartAtController(_calendarContext, _meetingBuilder);
                }
                else
                {
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

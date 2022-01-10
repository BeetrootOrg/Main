using CalendarApp.Console.Controllers.Interfaces;
using System;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingStartAtController : IController
    {
        private readonly string _meetingName;

        public CreateMeetingStartAtController(string meetingName)
        {
            _meetingName = meetingName;
        }

        public IController Action()
        {
            var input = ReadLine();

            if (DateTime.TryParse(input, out var startAt))
            {
                return new CreateMeetingDurationController(_meetingName, startAt);
            }

            return this;
        }

        public void Render()
        {
            WriteLine("Enter start datetime:");
        }
    }
}

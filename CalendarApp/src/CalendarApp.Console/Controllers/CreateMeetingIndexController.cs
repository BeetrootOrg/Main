using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Builders;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingIndexController : IController
    {
        private readonly CalendarContext _calendarContext;
        private readonly MeetingBuilder _meetingBuilder;
        private readonly string _meetingName;
        private readonly int _meetingIndex;

        public CreateMeetingIndexController(MeetingBuilder meetingBuilder,
            CalendarContext calendarContext,
            int meetingIndex,
            string meetingName)
        {
            _meetingBuilder = meetingBuilder;
            _calendarContext = calendarContext;
            _meetingName = meetingName;
            _meetingIndex = meetingIndex;
        }

        public IController Action()
        {
            _meetingBuilder.SetMeetingIndex(_meetingIndex);
            _meetingBuilder.SetMeetingName(_meetingName);
            return new CreateMeetingStartAtController(_calendarContext, _meetingBuilder);
        }

        public void Render()
        {
        }
    }
}

using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Domain.Builders;
using CalendarApp.Domain.Services.Interfaces;
using System;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingController : IController
    {
        private readonly IMeetingService _meetingService;
        private readonly CalendarContext _calendarContext;
        private readonly MeetingBuilder _meetingBuilder;
        private readonly NameMode _mode;

        public CreateMeetingController(IMeetingService meetingService, CalendarContext calendarContext, 
            MeetingBuilder meetingBuilder)
        {
            _meetingService = meetingService;
            _calendarContext = calendarContext;
            _meetingBuilder = meetingBuilder;
            _mode = new NameMode();
            _mode.nameMode = Mode.CreateName;
        }
        public CreateMeetingController(IMeetingService meetingService, CalendarContext calendarContext,
            MeetingBuilder meetingBuilder, NameMode mode)
        {
            _meetingService = meetingService;
            _calendarContext = calendarContext;
            _meetingBuilder = meetingBuilder;
            _mode = new NameMode();
            _mode = mode;
        }

        public IController Action()
        {
            try
            {             

                switch (_mode.nameMode)
                {
                    case Mode.CreateName:
                        {
                            var meeting = _meetingBuilder.Build();
                            if (_meetingService.OverlapWithAny(_calendarContext.Meetings, meeting))
                            {
                                return new CreateMeetingOverlapController(_calendarContext);
                            }
                            _calendarContext.Meetings.Add(meeting);
                            return new MainMenuController(_calendarContext);
                        }
                    case Mode.EditName:
                        {
                            var meeting = _meetingBuilder.Build();
                            if (_meetingService.OverlapWithAny(_calendarContext.Meetings, meeting))
                            {
                                return new CreateMeetingOverlapController(_calendarContext);
                            }
                            _calendarContext.Meetings.RemoveAt(_mode.index);
                            _calendarContext.Meetings.Insert(_mode.index, meeting);
                            return new MainMenuController(_calendarContext);
                        }
                    case Mode.DeleteName:
                        {
                            //var meeting = _meetingBuilder.Build();
                            //if (_meetingService.OverlapWithAny(_calendarContext.Meetings, meeting))
                            //{
                            //    return new CreateMeetingOverlapController(_calendarContext);
                            //}
                            _calendarContext.Meetings.RemoveAt(_mode.index);
                            return new MainMenuController(_calendarContext);
                        }
                    default: 
                        {
                            // _calendarContext.Meetings.Add(meeting);
                            return new MainMenuController(_calendarContext);
                        }
                }

                // _calendarContext.Meetings.Add(meeting);
                // return new MainMenuController(_calendarContext);
            }
            catch (ArgumentNullException)
            {
                return new MainMenuController(_calendarContext);
            }
        }

        public void Render()
        {
        }
    }
}

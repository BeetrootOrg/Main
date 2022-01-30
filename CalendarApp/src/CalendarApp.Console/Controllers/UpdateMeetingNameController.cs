using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Contracts.Models;
using CalendarApp.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Console.Controllers
{
    internal class UpdateMeetingNameController : IController
    {
        private readonly IMeetingService _meetingService;
        private readonly CalendarContext _calendarContext;

        private readonly string _meetingName;
        private readonly DateTime _startAt;
        private readonly TimeSpan _duration;
        private readonly string _roomName;

        public UpdateMeetingNameController(IMeetingService meetingService, CalendarContext calendarContext,
            string meetingName, DateTime startAt, TimeSpan duration, string roomName)
        {
            _meetingService = meetingService;
            _calendarContext = calendarContext;
            _meetingName = meetingName;
            _startAt = startAt;
            _duration = duration;
            _roomName = roomName;
        }

        public IController Action()
        {
            var fiend = FiendByName(_meetingName);
            if (fiend != null)
            {
                _meetingService.Update(fiend, _startAt, _duration, _roomName);
            }
            return new MainMenuController(_calendarContext);
        }
        public Meeting FiendByName(string name)
        {
            var valid = _calendarContext.Meetings.FirstOrDefault(x => x.Name == name);
                return valid;
        }
        public void Render()
        {
        }
    }
}

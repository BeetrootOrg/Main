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
    internal class RemoveByNameMeetingController : IController
    {
         
        private readonly IMeetingService _meetingService;
        private readonly CalendarContext _calendarContext;

        private readonly string _meetingName;
        private readonly DateTime _startAt;
        private readonly TimeSpan _duration;
        private readonly string _roomName;

        public RemoveByNameMeetingController(IMeetingService meetingService, CalendarContext calendarContext,
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
            RemoveByName(_meetingName);
            
            return new MainMenuController(_calendarContext);
        }
        public void RemoveByName(string name)
        {
            var valid = _calendarContext.Meetings.FirstOrDefault(x => x.Name == name);
            if (valid != null)
            {
                _calendarContext.Meetings.Remove(valid);
            }
        }
        public void Render()
        {
        }
    }
}


using CalendarApp.Contracts.Models;
using System;

namespace CalendarApp.Domain.Builders
{
    public enum Mode
    {
        CreateName,
        EditName,
        DeleteName,
        DefaultName
    }
    public class NameMode
    {
        public Mode nameMode;
        public int index;
    }
    public class MeetingBuilder
    {
        public string meetingName { get; private set; }
        private string _roomName;
        private DateTime? _startAt;
        private TimeSpan? _duration;
        public MeetingBuilder SetMeetingName(string meetingName)
        {
            if (string.IsNullOrEmpty(meetingName))
            {
                throw new ArgumentException($"Argument {nameof(meetingName)} can't be null or empty");
            }

            this.meetingName = meetingName;
            return this;
        }

        public MeetingBuilder SetMeetingRoom(string roomName)
        {
            if (string.IsNullOrEmpty(roomName))
            {
                throw new ArgumentException($"Argument {nameof(roomName)} can't be null or empty");
            }

            _roomName = roomName;
            return this;
        }

        public MeetingBuilder SetMeetingStartAt(string startAtInput)
        {
            if (!DateTime.TryParse(startAtInput, out var startAt))
            {
                throw new ArgumentException($"Argument {nameof(startAtInput)} can't be parsed");
            }

            if (startAt < DateTime.Now)
            {
                throw new ArgumentException($"Argument {nameof(startAtInput)} can't be in past");
            }

            _startAt = startAt;
            return this;
        }

        public MeetingBuilder SetMeetingDuration(string durationInput)
        {
            if (!int.TryParse(durationInput, out var durationInMinutes))
            {
                throw new ArgumentException($"Argument {nameof(durationInput)} can't be parsed");
            }

            if (durationInMinutes <= 0)
            {
                throw new ArgumentException($"Argument {nameof(durationInput)} can't be negative or zero");
            }

            _duration = TimeSpan.FromMinutes(durationInMinutes);
            return this;
        }

        public Meeting Build()
        {
            if (meetingName == null)
            {
                throw new ArgumentNullException(nameof(meetingName));
            }

            if (_roomName == null)
            {
                throw new ArgumentNullException(nameof(_roomName));
            }

            if (_startAt == null)
            {
                throw new ArgumentNullException(nameof(_startAt));
            }

            if (_duration == null)
            {
                throw new ArgumentNullException(nameof(_duration));
            }

            return new Meeting(meetingName, _startAt.Value, _duration.Value, new Room(_roomName));
        }
    }
}

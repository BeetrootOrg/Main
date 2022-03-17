using CalendarApp.Contracts.Models;
using System;

namespace CalendarApp.Domain.Builders
{
    public class MeetingBuilder
    {
        private string _meetingName;
        private string _roomName;
        private int? _meetingId;
        private DateTime? _startAt;
        private TimeSpan? _duration;

        public MeetingBuilder SetMeetingIndex(int meetingId)
        {
            if (_meetingId == null)
            {
                _meetingId = meetingId;
            }
            return this;
        }

        public MeetingBuilder SetMeetingName(string meetingName)
        {
            if (string.IsNullOrEmpty(meetingName))
            {
                throw new ArgumentException($"Argument {nameof(meetingName)} can't be null or empty");
            }

            _meetingName = meetingName;
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
            if (_meetingName == null)
            {
                throw new ArgumentNullException(nameof(_meetingName));
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

            return new Meeting(_meetingName, _startAt.Value, _duration.Value, new Room(_roomName), (int)_meetingId);
        }
    }
}

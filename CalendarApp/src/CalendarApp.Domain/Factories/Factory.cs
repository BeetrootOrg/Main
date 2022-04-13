using CalendarApp.Domain.Services;
using CalendarApp.Domain.Services.Interfaces;

namespace CalendarApp.Domain.Factories
{
    public static class Factory
    {
        public static IMeetingService CreateMeetingService() => new MeetingService();
    }
}

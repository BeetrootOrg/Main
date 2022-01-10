using CalendarApp.Console.Controllers.Interfaces;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class CreateMeetingNameController : IController
    {
        public IController Action()
        {
            var input = ReadLine();
            return new CreateMeetingStartAtController(input);
        }

        public void Render()
        {
            WriteLine("Enter meeting name:");
        }
    }
}

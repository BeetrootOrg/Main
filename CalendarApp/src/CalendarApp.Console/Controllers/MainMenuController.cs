using CalendarApp.Console.Controllers.Interfaces;
using static System.Console;

namespace CalendarApp.Console.Controllers
{
    internal class MainMenuController : IController
    {
        public IController Action()
        {
            var input = ReadLine();

            return input switch
            {
                "1" => new CreateMeetingNameController(),
                "0" => null,
                _ => this,
            };
        }

        public void Render()
        {
            Clear();
            WriteLine("1. Add meeting");
            WriteLine("0. Exit");
        }
    }
}

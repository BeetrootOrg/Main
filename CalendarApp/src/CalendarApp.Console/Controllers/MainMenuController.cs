using CalendarApp.Console.Controllers.Interfaces;

namespace CalendarApp.Console.Controllers
{
    using System;

    internal class MainMenuController : IController
    {
        public IController Action()
        {
            var input = Console.ReadLine();

            return input switch
            {
                "1" => new CreateMeetingController(),
                "0" => null,
                _ => this,
            };
        }

        public void Render()
        {
            Console.Clear();
            Console.WriteLine("1. Add meeting");
            Console.WriteLine("0. Exit");
        }
    }
}

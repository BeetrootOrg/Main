namespace CalendarApp.Console
{
    using CalendarApp.Console.Context;
    using CalendarApp.Console.Controllers;
    using CalendarApp.Console.Controllers.Interfaces;
    using System.IO;
    using static System.Console;

    public class Program
    {
        private const string Filename = "dump.json";

        private static void Main()
        {
            WriteLine("\r\n a.tkachenko/homework/21-Calendar \r\n");

            var context = new CalendarContext();

            if (File.Exists(Filename))
            {
                context.ReadFromFile(Filename);
            }

            IController controller = new MainMenuController(context);

            while (controller != null)
            {
                controller.Render();
                controller = controller.Action();
            }

            context.WriteToFile(Filename);
        }
    }

}

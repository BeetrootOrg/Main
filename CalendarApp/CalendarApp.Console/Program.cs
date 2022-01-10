namespace CalendarApp.Console
{
    using CalendarApp.Console.Context;
    using CalendarApp.Console.Controllers;
    using CalendarApp.Console.Controllers.Interfaces;
    using System.IO;

    public class Program
    {
        private const string Filename = "dump.bin";

        private static void Main()
        {
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
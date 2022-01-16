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

        /*
          16-jan-22 15:30:00
          interview
          - додати валідацію на унікальність імені мітингу (більше не існує мітингу з таким іменем в контексті застосунку)

          - додати можливість редагування мітингу за іменем (редагувати можна всі поля крім імені мітингу)
          - додати можливість видалити мітинг за іменем
         */
        private static void Main()
        {
            WriteLine("\r\n a.tkachenko/homework/21-asinc \r\n");

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

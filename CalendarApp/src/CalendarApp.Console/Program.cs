namespace CalendarApp.Console
{
    using CalendarApp.Console.Context;
    using CalendarApp.Console.Controllers;
    using CalendarApp.Console.Controllers.Interfaces;

    public class Program
    {
        private static void Main()
        {
            var context = new CalendarContext();
            IController controller = new MainMenuController(context);

            while (controller != null)
            {
                controller.Render();
                controller = controller.Action();
            }
        }
    }

}

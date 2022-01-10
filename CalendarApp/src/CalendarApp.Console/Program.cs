namespace CalendarApp.Console
{
    using CalendarApp.Console.Controllers;
    using CalendarApp.Console.Controllers.Interfaces;

    public class Program
    {
        private static void Main()
        {
            IController controller = new MainMenuController();

            while (controller != null)
            {
                controller.Render();
                controller = controller.Action();
            }
        }
    }

}

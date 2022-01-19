namespace CalendarApp.Console.Controllers.Interfaces
{
    internal interface IController
    {
        void Render();
        IController Action();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Console.Controllers.Interfaces
{
    internal interface IController
    {
        void Render();
        IController Action();
    }
}

using CalendarApp.Console.Context;
using CalendarApp.Console.Controllers.Interfaces;
using CalendarApp.Contracts.Models;
using CalendarApp.Domain.Builders;
using CalendarApp.Domain.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Console.Controllers
{
    internal class ApiIntegrationController : IController
    {
        private HttpClient _httpClient;
        private CalendarContext _calendarContext;

        public ApiIntegrationController(CalendarContext calendarContext)
        {
            _httpClient = new HttpClient();
            _calendarContext = calendarContext;
        }

        public async Task<IController> Action()
        {
            var result = await _httpClient.GetAsync("https://cat-fact.herokuapp.com/facts/random");
            var catFact = JsonConvert.DeserializeObject<CatFact>(await result.Content.ReadAsStringAsync());
            System.Console.WriteLine(catFact.Text);
            return new MainMenuController(_calendarContext);
        }

        public void Render()
        {

        }

        IController IController.Action()
        {
            throw new NotImplementedException();
        }
    }
}

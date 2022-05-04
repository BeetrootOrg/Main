using EventCreator.Database;
using EventCreator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EventCreator.Controllers
{
    public class EventDatasController : Controller
    {
        private static readonly IEnumerable<EventData> events = new List<EventData>
        {
            new EventData
            {
                Id = 1,
                EventDescription = "Wow awesome!",
                EventName = "Best event",
                PeopleJoined= 5,
            }
        };
        // GET: HomeController1
        private readonly EventDBContext _events;

        public EventDatasController(EventDBContext events)
        {
            _events = events;
        }

        public ActionResult Index()
        {
            return View(events);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpPost()]
        public async Task<ActionResult> Create([FromForm] EventData eventData,
            CancellationToken cancellationToken = default) 
        {
            var _event = new EventData
            {
                EventName = eventData.EventName,
                EventDescription = eventData.EventDescription,
                PeopleJoined = eventData.PeopleJoined,
            };
            await _events.AddAsync(_event, cancellationToken);
            await _events.SaveChangesAsync(cancellationToken);
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]



        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is EventDatasController controller &&
                   EqualityComparer<EventDBContext>.Default.Equals(_events, controller._events);
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}

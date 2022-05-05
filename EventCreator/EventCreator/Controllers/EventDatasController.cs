using EventCreator.Database;
using EventCreator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EventCreator.Controllers
{
    public class EventDatasController : Controller
    {
        // GET: HomeController1
        private readonly EventDBContext _events;

        public EventDatasController(EventDBContext events)
        {
            _events = events;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _events.EventData.ToListAsync());
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


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                EventData eventD = await _events.EventData.FirstOrDefaultAsync(p => p.Id == id);
                if (eventD != null)
                    return View(eventD);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EventData eventD)
        {
            _events.EventData.Update(eventD);
            await _events.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                EventData evenD = await _events.EventData.FirstOrDefaultAsync(p => p.Id == id);
                if (evenD != null)
                    return View(evenD);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                EventData user = await _events.EventData.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                {
                    _events.EventData.Remove(user);
                    await _events.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
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

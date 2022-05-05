using EventCreator.Database;
using EventCreator.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Threading;
using System.Threading.Tasks;

namespace EventCreator.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventsDBContext _events;

        public EventsController(EventsDBContext events)
        {
            _events = events;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _events.Events.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] Event eventData,
            CancellationToken cancellationToken = default)
        {
            _ = await _events.AddAsync(eventData, cancellationToken);
            _ = await _events.SaveChangesAsync(cancellationToken);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Event @event = await _events.Events.FirstOrDefaultAsync(p => p.Id == id);
            return @event != null ? View(@event) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Event @event)
        {
            _ = _events.Events.Update(@event);
            _ = await _events.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            Event evenD = await _events.Events.FirstOrDefaultAsync(p => p.Id == id);
            return evenD != null ? View(evenD) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Event user = await _events.Events.FirstOrDefaultAsync(p => p.Id == id);
            if (user != null)
            {
                _ = _events.Events.Remove(user);
                _ = await _events.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}

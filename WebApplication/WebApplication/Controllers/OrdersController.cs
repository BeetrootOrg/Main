#nullable disable
using System.Data;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using WebApplication.Database;
using WebApplication.Models;
using System.IO;


namespace WebApplication.Controllers
{

    public class OrdersController : Controller
    {



        private readonly OrderDbContext _context;
  
        public OrdersController(OrderDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Flash,Customer,Ord,Steel,Surface,Thickness,Qty,Bending,Dimension1,Dimension2,Note,Manager,Operator,Modified")] Order order)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    
                    _context.Orders.Add(order);
                    _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Flash,Customer,Ord,Steel,Surface,Thickness,Qty,Bending,Dimension1,Dimension2,Note,Manager,Operator,Modified")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(long id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }


        public void CreatePdf(long id)
        {
            var ind = _context.Orders
                .AsEnumerable()
                .TakeWhile(x => x.Id != id)
                .Count();
            Order ord = _context.Orders
                 .AsEnumerable()
                 .ElementAt(ind);
            string manag=(ord.Manager).ToString();
            string oper = (ord.Operator).ToString();
            PdfDocument pdf = new PdfDocument();
            PdfPageBase page = pdf.Pages.Add();
            page.Canvas.DrawString(manag, new PdfTrueTypeFont(new Font("Arial", 20f), true), new PdfSolidBrush(Color.Black), 10, 10);
            page.Canvas.DrawString(oper, new PdfTrueTypeFont(new Font("Arial", 20f), true), new PdfSolidBrush(Color.Black), 10, 25);

            //pdf.LoadFromStream(Stream stream);
            pdf.SaveToFile("c:\\Temp 2\\blank.pdf");
            //pdf.SaveToFile("c:\\Temp 2\\" + Guid.NewGuid().ToString() + ".pdf");
            //< asp:Button ID = "btnHtml2PDF" runat = "server" Text = "Create Pdf" OnClick = "btnHtml2PDF_Click" />

            View(ord);
        }




    }


}

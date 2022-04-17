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
using System.Reflection.Metadata;

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
        public FileStreamResult CreatePdf(long id)
        {
            var ind = _context.Orders
                .AsEnumerable()
                .TakeWhile(x => x.Id != id)
                .Count();
            Order ord = _context.Orders
                 .AsEnumerable()
                 .ElementAt(ind);
            string manag = (ord.Manager).ToString();
            string oper = (ord.Operator).ToString();
            PdfDocument pdf = new PdfDocument();
            PdfPageBase page = pdf.Pages.Add();
            PdfPen pen = new PdfPen(PdfBrushes.Red, 0.5f);
            PdfPen pen3 = new PdfPen(PdfBrushes.Black, 0.5f);
            PdfPen pen2 = new PdfPen(PdfBrushes.Red, 2.5f);
            PdfTrueTypeFont fnt1 = new PdfTrueTypeFont(new Font("Arial", 20f), true);
            PdfTrueTypeFont fnt2 = new PdfTrueTypeFont(new Font("Times New Roman", 25f, FontStyle.Bold), true);
            PdfTrueTypeFont fnt3 = new PdfTrueTypeFont(new Font("Times New Roman", 18f, FontStyle.Italic), true);
            page.Canvas.DrawLine(pen, new PointF(0, 60), new PointF(600, 60));
            page.Canvas.DrawArc(pen2, new RectangleF(15.0f, 5.0f, 40.0f, 50.0f), 0.0f, 360.0f);
            page.Canvas.DrawArc(pen2, new RectangleF(10.0f, 10.0f, 50.0f, 40.0f), 0.0f, 360.0f);
            page.Canvas.DrawString("P", new PdfTrueTypeFont(new Font("Arial", 45f, FontStyle.Bold), true), new PdfSolidBrush(Color.Red), 21, 4);
            page.Canvas.DrawString("Vasia Petrushov Inc.", new PdfTrueTypeFont(new Font("Times New Roman", 50f), true), new PdfSolidBrush(Color.Red), 70, 5);
            page.Canvas.DrawString(("ЗАКАЗ №"+ (ord.Ord).ToString()), fnt2, new PdfSolidBrush(Color.Black), 180, 100);
            page.Canvas.DrawString(("от " + (ord.Modified).ToString()), fnt3, new PdfSolidBrush(Color.Black), 150, 130);
            page.Canvas.DrawString(("заказчик: " + (ord.Customer).ToString()), fnt3, new PdfSolidBrush(Color.Black), 0, 200);
            page.Canvas.DrawString(("эл. носитель: " + (ord.Flash).ToString()), fnt3, new PdfSolidBrush(Color.Black), 300, 200);
            page.Canvas.DrawString(("материал: " + (ord.Steel).ToString()), fnt3, new PdfSolidBrush(Color.Black), 0, 230);
            page.Canvas.DrawString(("чистота обработки: " + (ord.Surface).ToString()), fnt3, new PdfSolidBrush(Color.Black), 300, 230);
            page.Canvas.DrawString(("размеры: " + (ord.Dimension1).ToString() + "мм × " + (ord.Dimension2).ToString()+"мм × "+ (ord.Thickness).ToString() + "мм"), fnt3, new PdfSolidBrush(Color.Black), 100, 260);
            page.Canvas.DrawString(("количество: " + (ord.Qty).ToString() + " шт"), fnt3, new PdfSolidBrush(Color.Black), 180, 290);
            page.Canvas.DrawString(("примечание: " + (ord.Note).ToString()), fnt3, new PdfSolidBrush(Color.Black), 180, 320);
            page.Canvas.DrawString(("менеджер: " + (ord.Manager).ToString()), fnt3, new PdfSolidBrush(Color.Black), 0, 360);
            page.Canvas.DrawLine(pen3, new PointF(80, 380), new PointF(600, 380));
            page.Canvas.DrawString(("оператор: " + (ord.Operator).ToString()), fnt3, new PdfSolidBrush(Color.Black), 0, 400);
            page.Canvas.DrawLine(pen3, new PointF(80, 420), new PointF(600, 420));
            pdf.SaveToFile("c:\\Temp 2\\blank.pdf");
            FileStream stream = new FileStream("c:\\Temp 2\\blank.pdf", FileMode.Open);
            stream.Position = 0;
            return File(stream, "application/pdf");
        }
    }
}

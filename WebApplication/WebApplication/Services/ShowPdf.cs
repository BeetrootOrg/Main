using System.Data;
using Microsoft.AspNetCore.Mvc;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Drawing;
using WebApplication.Database;
using WebApplication.Models;
using WebApplication.Services.Interfaces;

namespace WebApplication.Services
{
    public class ShowPdf:IShowPdf
    {
        public FileStreamResult CreatePdf(long id, OrderDbContext _context)
        {
            Order ord = (Order)_context.Orders
                .Where(x => x.Id == id)
                .FirstOrDefault();
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
            page.Canvas.DrawString(("ЗАКАЗ №" + (ord.Ord)), fnt2, new PdfSolidBrush(Color.Black), 180, 100);
            page.Canvas.DrawString(("от " + (ord.Modified).ToString()), fnt3, new PdfSolidBrush(Color.Black), 150, 130);
            page.Canvas.DrawString(("заказчик: " + (ord.Customer)), fnt3, new PdfSolidBrush(Color.Black), 0, 200);
            page.Canvas.DrawString(("эл. носитель: " + (ord.Flash)), fnt3, new PdfSolidBrush(Color.Black), 300, 200);
            page.Canvas.DrawString(("материал: " + (ord.Steel)), fnt3, new PdfSolidBrush(Color.Black), 0, 230);
            page.Canvas.DrawString(("чистота обработки: " + (ord.Surface).ToString()), fnt3, new PdfSolidBrush(Color.Black), 300, 230);
            page.Canvas.DrawString(("размеры: " + (ord.Dimension1).ToString() + "мм × " + (ord.Dimension2).ToString() + "мм × " + (ord.Thickness).ToString() + "мм"), fnt3, new PdfSolidBrush(Color.Black), 100, 260);
          
            page.Canvas.DrawString(("количество: " + (ord.Qty).ToString() + " шт"), fnt3, new PdfSolidBrush(Color.Black), 180, 290);
            string bend;
            if (ord.Bending != null)
            {
                bend = "да";
            }
            else
            {
                bend = "нет";
            }
            page.Canvas.DrawString(("гибка: " + bend), fnt3, new PdfSolidBrush(Color.Black), 180, 310);
            page.Canvas.DrawString(("примечание: " + (ord.Note).ToString()), fnt3, new PdfSolidBrush(Color.Black), 180, 330);
            page.Canvas.DrawString(("менеджер: " + (ord.Manager)), fnt3, new PdfSolidBrush(Color.Black), 0, 380);
            page.Canvas.DrawLine(pen3, new PointF(80, 400), new PointF(600, 400));
            page.Canvas.DrawString(("оператор: " + (ord.Operator)), fnt3, new PdfSolidBrush(Color.Black), 0, 420);
            page.Canvas.DrawLine(pen3, new PointF(80, 440), new PointF(600, 440));
            pdf.SaveToFile("c:\\Temp 2\\blank.pdf");
            FileStream stream = new FileStream("c:\\Temp 2\\blank.pdf", FileMode.Open);
            stream.Position = 0;
            return new FileStreamResult(stream, "application/pdf");
        }
    }
}

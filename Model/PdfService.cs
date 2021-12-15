using System;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Linq;

namespace FurnitureStoreApp.Model
{
    public class PdfService
    {
        private ProductDatabaseEntities entities;

        public PdfService()
        {
            entities = new ProductDatabaseEntities();
        }

        public void writeToPdf(CustomerDTO customer)
        {
            string pdfName = customer.Name + ".pdf";
            PdfWriter pdfWriter = new PdfWriter(Environment.CurrentDirectory + "\\" + pdfName);
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document document = new Document(pdf);
            Paragraph header = new Paragraph("Purchase of " +customer.Name).SetTextAlignment(TextAlignment.CENTER).SetFontSize(22);
            document.Add(header);
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);
            Paragraph basicData = new Paragraph("Id number: " + customer.PurchaseID.ToString() + " Purchase date: " + customer.Date);
            document.Add(basicData);

            var purchases = from p in entities.Purchases where p.CustomerID == 98  select p;
            foreach (Purchases item in purchases)
            {
                Paragraph data = new Paragraph(item.Price.ToString());
                document.Add(data);
            }

            document.Close();
        }

    }
}

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
            Paragraph header = new Paragraph("*Xy furniture store*").SetTextAlignment(TextAlignment.CENTER).SetFontSize(22);
            document.Add(header);
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);
            Paragraph basicData = new Paragraph("Id number: " + customer.PurchaseID.ToString() 
                + "\nPurchase date: " + customer.Date + "\nCustomer Name: " + customer.Name + "\n\n");
       
            document.Add(basicData);
            

            var purchases = from p in entities.Purchases where p.CustomerID == customer.PurchaseID  select p;
            int LineDrawn = 0;

            foreach (Purchases item in purchases)
            {
                int dashedLineNeeded = purchases.Count() - 1;
               

                var prod = entities.Product.Find(item.ProductID);
                string prodName = prod.Name;
                 
                Paragraph product = new Paragraph("Bought product: " + prodName);
                Paragraph unitprice = new Paragraph("Unit price: " +item.Price.ToString());
                Paragraph quantity = new Paragraph("Number of units bought: " + item.Quantity);
                Paragraph price = new Paragraph("Subtotal: " + item.Quantity * item.Price);
                LineSeparator line = new LineSeparator(new DashedLine());
                document.Add(product);
                document.Add(unitprice);
                document.Add(quantity);
                document.Add(price);

                if (LineDrawn < dashedLineNeeded)
                {
                    LineDrawn++;
                    document.Add(line);
                }
              
                
       
            }
      
            document.Add(ls);
            Paragraph fullPrice = new Paragraph("Full price: " + customer.FullPrice).SetTextAlignment(TextAlignment.RIGHT).SetFontSize(14).SetBold();
            document.Add(fullPrice);


            document.Close();
        }

    }
}

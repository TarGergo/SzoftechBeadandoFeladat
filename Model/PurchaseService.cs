using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStoreApp.Model
{
    class PurchaseService
    {
        private ProductDatabaseEntities productDatabaseEntities;
        private string Message;

        public PurchaseService()
        {
            productDatabaseEntities = new ProductDatabaseEntities();
        }

        public List<PurchaseDTO> getAllPurchase()
        {
            List<PurchaseDTO> purchaseDTOs = new List<PurchaseDTO>();

            try
            {
                var purchases = from p in productDatabaseEntities.Purchases
                                select p;
                

                foreach (var p in purchases)
                {
                    purchaseDTOs.Add(new PurchaseDTO
                    {
                        Id = p.Id,
                        ProductID = p.ProductID,
                        CustomerID = p.CustomerID,
                        Quantity = p.Quantity,
                        Price = p.Price
                    }) ;
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
            return purchaseDTOs;
        }

        public string settingMessage()
        {
            return Message;
        }

        public void add(PurchaseDTO newPurchase)
        {
            try
            {
                var purchashedProduct = new Product();
                var pr = from p in productDatabaseEntities.Product where p.Id == newPurchase.ProductID  select p.Price;
               
                purchashedProduct.Price = pr.Sum();

                var purch = new Purchases();
                purch.CustomerID = newPurchase.CustomerID;
                purch.ProductID = newPurchase.ProductID;
                purch.Price = purchashedProduct.Price;
                purch.Quantity = newPurchase.Quantity;

                int price = purch.Price;
                int quantity = purch.Quantity;
                var cust = from c in productDatabaseEntities.Customers where c.PurchaseID == purch.CustomerID select c.PurchaseID;
                int cc = cust.Sum();

                int priceOfALL = quantity * price;

                var realCust = productDatabaseEntities.Customers.Find(cc);
                realCust.FullPrice += priceOfALL;

                var product = from p in productDatabaseEntities.Product where p.Id == purch.ProductID select p.Id;
                int pid = product.Sum();

                var realProduct = productDatabaseEntities.Product.Find(pid);
                if (quantity > realProduct.Quantity)
                {
                    Message = "You dont even have that many item you bozo";
                }
                else
                {
                    //realProduct.Quantity -= quantity;

                    productDatabaseEntities.Purchases.Add(purch);
                    productDatabaseEntities.SaveChanges();

                    Message = "Success";
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void delete(int idToDelete, int custId)
        {
            var deletableProduct = from p in productDatabaseEntities.Purchases where p.ProductID == idToDelete && p.CustomerID == custId select p.Id;
            int asd = deletableProduct.Sum();

            var purchase = productDatabaseEntities.Purchases.Find(asd);
            productDatabaseEntities.Purchases.Remove(purchase);

            productDatabaseEntities.SaveChanges();


            int price = purchase.Price;
            int quantity = purchase.Quantity;
            var cust = from c in productDatabaseEntities.Customers where c.PurchaseID == purchase.CustomerID select c.PurchaseID;
            int cid = cust.Sum();
            int priceOfAll = quantity * price;

            var realCust = productDatabaseEntities.Customers.Find(cid);
            realCust.FullPrice -= priceOfAll;

            Message = "Purchase successfully removed!";
            productDatabaseEntities.SaveChanges();

        }

        public void edit(PurchaseDTO purchaseToEdit)
        {
            try
            {
                var purchase = productDatabaseEntities.Purchases.Find(purchaseToEdit.Id);
                int? productBought = purchase.Quantity; // 40 sold
                purchase.Quantity = purchaseToEdit.Quantity;

                var product = from p in productDatabaseEntities.Product where p.Id == purchase.ProductID select p.Id;
                int pid = product.Sum();
                var realProduct = productDatabaseEntities.Product.Find(pid);
                int? productLeft = realProduct.Quantity; //20 left. 40 sold. 40 -> 35 == 25 //20 left. 40 sold. 40 -> 45 == 15
                realProduct.Quantity += productBought; // 60 at this point

                var customer = from c in productDatabaseEntities.Customers where c.PurchaseID == purchase.CustomerID select c.PurchaseID;
                int cid = customer.Sum();
                var realCustomer = productDatabaseEntities.Customers.Find(cid);
                realCustomer.FullPrice -= (int)productBought * purchase.Price;


                if (purchaseToEdit.Quantity > realProduct.Quantity)
                {
                    Message = "You cant buy more, if we dont have more";
                }
                else
                {
                    realCustomer.FullPrice += purchase.Quantity * purchase.Price;
                    realProduct.Quantity -= purchase.Quantity;
                    Message = "Number of brought products successfully edited!";
                    productDatabaseEntities.SaveChanges();
                }

            
       
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}

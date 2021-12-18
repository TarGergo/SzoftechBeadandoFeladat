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
        public bool success { get; set; }
        public PurchaseService()
        {
            productDatabaseEntities = new ProductDatabaseEntities();
            success = false;
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
           /*     var cust = from c in productDatabaseEntities.Customers where c.PurchaseID == purch.CustomerID select c.PurchaseID;
                int cc = cust.Sum();

                int priceOfALL = quantity * price;

                var realCust = productDatabaseEntities.Customers.Find(cc);
                realCust.FullPrice += priceOfALL;  */

                var product = from p in productDatabaseEntities.Product where p.Id == purch.ProductID select p.Id;
                int pid = product.Sum();

                var realProduct = productDatabaseEntities.Product.Find(pid);
                if (quantity > realProduct.Quantity)
                {
                    Message = "You dont even have that many item you bozo";
                    success = false;
                }
                else
                {
                    //realProduct.Quantity -= quantity;
                    //productService.editIfPurchaseAdded(newPurchase.ProductID, newPurchase.Quantity);
                    success = true;
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

        public PurchaseDTO searchPurchase(int id)
        {
            PurchaseDTO purchaseDTO = null;

            try
            {
                var purchase = productDatabaseEntities.Purchases.Find(id);
                if (purchase !=null)
                {
                    purchaseDTO = new PurchaseDTO()
                    {
                        Id = purchase.Id,
                        CustomerID = purchase.CustomerID,
                        ProductID = purchase.ProductID,
                        Price = purchase.Price,
                        Quantity = purchase.Quantity
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }

            return purchaseDTO;

        } 

        public void delete(int primaryid)
        {
           
            var purchase = productDatabaseEntities.Purchases.Find(primaryid);
            productDatabaseEntities.Purchases.Remove(purchase);

            productDatabaseEntities.SaveChanges();


        /*   int price = purchase.Price;
            int quantity = purchase.Quantity;
            var cust = from c in productDatabaseEntities.Customers where c.PurchaseID == purchase.CustomerID select c.PurchaseID;
            int cid = cust.Sum();
            int priceOfAll = quantity * price;

            var realCust = productDatabaseEntities.Customers.Find(cid);
            realCust.FullPrice -= priceOfAll;
        */
            Message = "Purchase successfully removed!";
            productDatabaseEntities.SaveChanges();

        }

        public void edit(PurchaseDTO purchaseToEdit)
        {
            try
            {
                var purchase = productDatabaseEntities.Purchases.Find(purchaseToEdit.Id); //Finding purchase -> we bought 4
                int currentPurchaseQuantity = purchase.Quantity; // Here is the 4
                purchase.Quantity = purchaseToEdit.Quantity; // New purchases quantity -> 4 to 6/4 to 2 -> NOT SAVED YET
                var product = productDatabaseEntities.Product.Find(purchaseToEdit.ProductID); //The product (remaining units) ex: 10
                int? newProductQuantity = product.Quantity + currentPurchaseQuantity; //So atm we have 14
                                                                                      //Need to set the new quantity of the purchase. Need to decide if this is possible
                                                                                      //Product modifying occur in another void
                product.Quantity += currentPurchaseQuantity;

                //  temporary product quantity (14) <  new purchase (ex: 8)
                if (newProductQuantity < purchaseToEdit.Quantity)
                {
                    Message = "You cannot buy more, if we dont have more";
                    success = false;
                }
                else
                {
                    // product.Quantity -= purchaseToEdit.Quantity;
            
                    success = true;
                    Message = currentPurchaseQuantity.ToString();
                    productDatabaseEntities.SaveChanges();
                    //Here the purchase will be saved! Only the purchase!
                }
              
                

            
       
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}

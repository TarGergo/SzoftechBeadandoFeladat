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
                        PurchaseID = p.PurchaseID,
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

        public void add(PurchaseDTO newPurchase)
        {
            try
            {
                var purchashedProduct = new Product();
                var pr = from p in productDatabaseEntities.Product where p.Id == newPurchase.PurchaseID  select p.Price;
               
                purchashedProduct.Price = pr.Sum();


                var purch = new Purchases();
                purch.CustomerID = newPurchase.CustomerID;
                purch.PurchaseID = newPurchase.PurchaseID;
                purch.Price = purchashedProduct.Price;
                purch.Quantity = newPurchase.Quantity;

                productDatabaseEntities.Purchases.Add(purch);
                productDatabaseEntities.SaveChanges();

                int price = purch.Price;
                int quantity = purch.Quantity;
                var cust = from c in productDatabaseEntities.Customers where c.PurchaseID == purch.CustomerID select c.PurchaseID;
                int cc = cust.Sum();
                CustomerDTO customerDTO = new CustomerDTO();
                customerDTO.FullPrice = quantity * price;

                var realCust = productDatabaseEntities.Customers.Find(cc);
                realCust.FullPrice += customerDTO.FullPrice;
                

                productDatabaseEntities.SaveChanges();


            }
            catch (Exception)
            {

                throw;
            }
        }

        public void delete(int idToDelete, int custId)
        {
            var deletableProduct = from p in productDatabaseEntities.Purchases where p.PurchaseID == idToDelete && p.CustomerID == custId select p.Id;
            int asd = deletableProduct.Sum();

            var purchase = productDatabaseEntities.Purchases.Find(asd);
            productDatabaseEntities.Purchases.Remove(purchase);

            productDatabaseEntities.SaveChanges();

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStoreApp.Model
{
    class PurchaseService
    {
        private ProductDatabaseEntitiesOfPurchases productDatabaseEntitiesOfPurchases;

        public PurchaseService()
        {
            productDatabaseEntitiesOfPurchases = new ProductDatabaseEntitiesOfPurchases();
        }

        public List<PurchaseDTO> getAllPurchase()
        {
            List<PurchaseDTO> purchaseDTOs = new List<PurchaseDTO>();

            try
            {
                var purchases = from p in productDatabaseEntitiesOfPurchases.Purchases
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
                var purch = new Purchases();
                purch.CustomerID = newPurchase.CustomerID;
                purch.PurchaseID = newPurchase.PurchaseID;
                purch.Price = newPurchase.Price;
                purch.Quantity = newPurchase.Quantity;
              //  purch.Customers = newPurchase.Customer;

                productDatabaseEntitiesOfPurchases.Purchases.Add(purch);
                productDatabaseEntitiesOfPurchases.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

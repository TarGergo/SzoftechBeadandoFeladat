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
                var purch = new Purchases();
                purch.CustomerID = newPurchase.CustomerID;
                purch.PurchaseID = newPurchase.PurchaseID;
                purch.Price = newPurchase.Price;
                purch.Quantity = newPurchase.Quantity;

                productDatabaseEntities.Purchases.Add(purch);
                productDatabaseEntities.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

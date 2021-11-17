using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStoreApp.Model
{
    class CustomerService
    {
        private ProductDatabaseEntitiesOfPurchases productDatabaseEntitiesOfPurchases;

        public CustomerService()
        {
            productDatabaseEntitiesOfPurchases = new ProductDatabaseEntitiesOfPurchases();
        }

        public List<CustomerDTO> getAllCustomer()
        {
            List<CustomerDTO> allCustomer = new List<CustomerDTO>();

            try
            {
                var customers = from c in productDatabaseEntitiesOfPurchases.Customers select c;

                foreach (var item in customers)
                {
                    allCustomer.Add(new CustomerDTO
                    {
                        Name = item.Name,
                        Date = DateTime.Now,
                        PurchaseID = item.PurchaseID,
                        FullPrice = item.FullPrice,
                        Purchases = convertPurchaseToPurchaseDTO(item.Purchases)

                    });
                }
            }
            catch (Exception)
            {

                throw;
            }



            return allCustomer;
        }


        private ObservableCollection<PurchaseDTO> convertPurchaseToPurchaseDTO(ObservableCollection<Purchases> purchases)
        {
            ObservableCollection<PurchaseDTO> purchaseDTOs = new ObservableCollection<PurchaseDTO>();

            foreach (var item in purchases)
            {
                purchaseDTOs.Add(new PurchaseDTO
                {
                    PurchaseID = item.PurchaseID,
                    CustomerID = item.CustomerID,
                    Quantity = item.Quantity,
                    Price = item.Price

                });
            }



            return purchaseDTOs;

        }

        public void add(CustomerDTO newCustomer)
        {
            var customer = new Customers();
            customer.Name = newCustomer.Name;
            customer.Date = DateTime.Now;
            customer.FullPrice = newCustomer.FullPrice;
            customer.PurchaseID = newCustomer.PurchaseID;

            productDatabaseEntitiesOfPurchases.Customers.Add(customer);
            productDatabaseEntitiesOfPurchases.SaveChanges();

        }

    }
}

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
        private ProductDatabaseEntities productDatabaseEntitiesOfPurchases;

        public CustomerService()
        {
            productDatabaseEntitiesOfPurchases = new ProductDatabaseEntities();
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
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }



            return allCustomer;
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


        public void edit(CustomerDTO customerToEdit)
        {
            try
            {
               // var customer = productDatabaseEntitiesOfPurchases.Customers.Find(customerToEdit.PurchaseID);



            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}

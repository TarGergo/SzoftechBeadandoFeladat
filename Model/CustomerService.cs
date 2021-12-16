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
        private ProductDatabaseEntities productDatabaseEntities;

        public CustomerService()
        {
            productDatabaseEntities = new ProductDatabaseEntities();
        }

        public List<CustomerDTO> getAllCustomer()
        {
            List<CustomerDTO> allCustomer = new List<CustomerDTO>();

            try
            {
                var customers = from c in productDatabaseEntities.Customers select c;

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
            customer.FullPrice = 0;
            customer.PurchaseID = newCustomer.PurchaseID;

            productDatabaseEntities.Customers.Add(customer);
            productDatabaseEntities.SaveChanges();

        }


        public void edit(CustomerDTO customerToEdit)
        {
            try
            {
                var customer = productDatabaseEntities.Customers.Find(customerToEdit.PurchaseID);
                customer.Name = customerToEdit.Name;
                customer.FullPrice = customerToEdit.FullPrice;

                productDatabaseEntities.SaveChanges();



            }
            catch (Exception)
            {

                throw;
            }
        }

        public void delete(int idToDelete)
        {
            var customer = productDatabaseEntities.Customers.Find(idToDelete);
            productDatabaseEntities.Customers.Remove(customer);

            productDatabaseEntities.SaveChanges();


        }

        public CustomerDTO search(int idToFind)
        {
            CustomerDTO customerDTO = null;

            try
            {
                var customer = productDatabaseEntities.Customers.Find(idToFind);
                if (customer != null)
                {
                    customerDTO = new CustomerDTO()
                    {
                        Name = customer.Name,
                        Date = customer.Date,
                        FullPrice = customer.FullPrice
                    };
                }


            }
            catch (Exception)
            {

                throw;
            }


            return customerDTO;
        }


    }
}

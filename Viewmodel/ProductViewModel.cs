using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using FurnitureStoreApp.Model;
using FurnitureStoreApp.Viewmodel.Base;

namespace FurnitureStoreApp.Viewmodel
{
    public class ProductViewModel : BaseViewModel
    {
        public ObservableCollection<ProductDTO> Products { get; set; }
        public ProductDTO currentProduct { get; set; }
        public DefaultCommand addCommand { get; }
        public DefaultCommand editCommand { get; }
        public DefaultCommand deleteCommand { get; }
        public DefaultCommand searchCommand { get; }
        public string infoMessage { get; set; }
        private string errorMessage = "Something went wrong! Operation failed!";
        private ProductService productService;


        public ObservableCollection<PurchaseDTO> Purchases { get; set; }
        public PurchaseDTO currentPurchase { get; set; }
        private PurchaseService purchaseService;
        public DefaultCommand addPurchaseCommand { get; }


        public ObservableCollection<CustomerDTO> Customers { get; set; }
        private CustomerService customerService;
        public DefaultCommand addCustomerCommand { get; set; }
        public CustomerDTO currentCustomer { get; set; }


        public ProductViewModel()
        {
            productService = new ProductService();
            currentProduct = new ProductDTO();
            loadData();
            addCommand = new DefaultCommand(add);
            editCommand = new DefaultCommand(edit);
            deleteCommand = new DefaultCommand(delete);
            searchCommand = new DefaultCommand(search);


           
            Purchases = new ObservableCollection<PurchaseDTO>();
            currentPurchase = new PurchaseDTO();
            purchaseService = new PurchaseService();
            addPurchaseCommand = new DefaultCommand(addProduct);
            loadPurchase();

            Customers = new ObservableCollection<CustomerDTO>();
            customerService = new CustomerService();
            addCustomerCommand = new DefaultCommand(addCustomer);
            currentCustomer = new CustomerDTO();

            loadCustomers();

        }

        public void loadData()
        {
            Products = new ObservableCollection<ProductDTO>(productService.getAllProduct());
        }

        public void loadPurchase()
        {
            Purchases = new ObservableCollection<PurchaseDTO>(purchaseService.getAllPurchase());
        }

        public void loadCustomers()
        {
            Customers = new ObservableCollection<CustomerDTO>(customerService.getAllCustomer());
        }

     
        public void add()
        {
            try
            {
                bool isAdded = productService.add(currentProduct);
                loadData();
                if (isAdded)
                {
                    infoMessage = "Product successfully added to the database!";
                }
                else
                {
                    infoMessage = errorMessage;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void delete()
        {
            try
            {
                var isDeleted = productService.delete(currentProduct.Id);
                loadData();
                if (isDeleted)
                {
                    infoMessage = "Product Successfully deleted from the database!";
                }
                else
                {
                    infoMessage = errorMessage;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void edit()
        {
            try
            {
                var isEdited = productService.edit(currentProduct);
                loadData();
                if (isEdited)
                {
                    infoMessage = "Product successfully edited!";
                }
                else
                {
                    infoMessage = errorMessage;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void search()
        {
            try
            {
                ProductDTO searchedProduct = productService.search(currentProduct.Id);
                if (searchedProduct != null)
                {
                    currentProduct.Name = searchedProduct.Name;
                    currentProduct.Manufacturer = searchedProduct.Manufacturer;
                    currentProduct.Quantity = searchedProduct.Quantity;
                    currentProduct.Price = searchedProduct.Price;
                    currentProduct.Width = searchedProduct.Width;
                    currentProduct.Length = searchedProduct.Length;
                    currentProduct.Height = searchedProduct.Height;
                    infoMessage = currentProduct.Name + "is found!";
                }
                else
                {
                    infoMessage = "The product couldnt be found with the given id number";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void addProduct()
        {
            try
            {
                purchaseService.add(currentPurchase);
                loadPurchase();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void addCustomer()
        {
            try
            {
                customerService.add(currentCustomer);
                loadCustomers();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}

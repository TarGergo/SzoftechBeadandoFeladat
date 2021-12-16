using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace FurnitureStoreApp.Model
{
    public class ProductService
    {
        private ProductDatabaseEntities ProductDatabaseEntities;
      
        public ProductService()
        {
            ProductDatabaseEntities = new ProductDatabaseEntities();
        }

        public List<ProductDTO> getAllProduct()
        {
            List<ProductDTO> productDTOs = new List<ProductDTO>();

            try
            {
                var products = from pr in ProductDatabaseEntities.Product select pr;

                foreach (var pr in products)
                {
                    productDTOs.Add
                        (new ProductDTO
                        {
                            Id = pr.Id,
                            Name = pr.Name,
                            Manufacturer = pr.Manufacturer,
                            Quantity = pr.Quantity,
                            Price = pr.Price,
                            Width = pr.Width,
                            Length = pr.Length,
                            Height = pr.Height
                        }) ;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return productDTOs;
        }

        public bool add(ProductDTO newProduct)
        {
            bool isAdded = false;
            try
            {
                var product = new Product();
                product.Id = newProduct.Id;
                product.Name = newProduct.Name;
                product.Manufacturer = newProduct.Manufacturer;
                product.Quantity = newProduct.Quantity;
                product.Price = newProduct.Price;
                product.Width = newProduct.Width;
                product.Length = newProduct.Length;
                product.Height = newProduct.Height;

                ProductDatabaseEntities.Product.Add(product);
                var affectedRows = ProductDatabaseEntities.SaveChanges();

                isAdded = affectedRows > 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return isAdded;
        }

        public bool edit(ProductDTO productToEdit)
        {
            bool isEdited = false;

            try
            {
                var product = ProductDatabaseEntities.Product.Find(productToEdit.Id);
                product.Name = productToEdit.Name;
                product.Manufacturer = productToEdit.Manufacturer;
                product.Quantity = productToEdit.Quantity;
                product.Price = productToEdit.Price;
                product.Width = productToEdit.Width;
                product.Length = productToEdit.Length;
                product.Height = productToEdit.Height;

                var affectedRows = ProductDatabaseEntities.SaveChanges();

                isEdited = affectedRows > 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return isEdited;
        }

        public bool delete(int idToDelete)
        {
            bool isDeleted = false;

            try
            {
                var product = ProductDatabaseEntities.Product.Find(idToDelete);
                ProductDatabaseEntities.Product.Remove(product);

                var affectedRows = ProductDatabaseEntities.SaveChanges();

                isDeleted = affectedRows > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return isDeleted;
        }

        public ProductDTO search(int id)
        {
            ProductDTO productDTO = null;

            try
            {
                var product = ProductDatabaseEntities.Product.Find(id);
               
                if (product != null)
                {
                    productDTO = new ProductDTO()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Manufacturer = product.Manufacturer,
                        Quantity = product.Quantity,
                        Price = product.Price,
                        Width = product.Width,
                        Length = product.Length,
                        Height = product.Height
                    };

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return productDTO;
        }

      

    }
}

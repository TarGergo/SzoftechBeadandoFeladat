using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            catch (Exception)
            {

                throw;
            }

            return productDTOs;
        }

    }
}

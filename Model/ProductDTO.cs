using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStoreApp.Model
{
    class ProductDTO
    {
        public int MyProperty { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }
    }
}

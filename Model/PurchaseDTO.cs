using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureStoreApp.Viewmodel.Base;

namespace FurnitureStoreApp.Model
{
    public class PurchaseDTO : BaseViewModel
    {
        public int PurchaseID { get; set; }
        public int CustomerID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

     
    }
}

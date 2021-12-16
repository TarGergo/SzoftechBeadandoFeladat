using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureStoreApp.Viewmodel.Base;

namespace FurnitureStoreApp.Model
{
    public class CustomerDTO : BaseViewModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int PurchaseID { get; set; }
        public int FullPrice { get; set; }

    
    }
}

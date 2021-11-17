using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureStoreApp.Model;
using FurnitureStoreApp.Viewmodel.Base;

namespace FurnitureStoreApp.Viewmodel
{
    class PurchaseViewModel : BaseViewModel
    {
        public ObservableCollection<PurchaseDTO> Purchases { get; set; }
        public PurchaseDTO currentPurchase { get; set; }
        private PurchaseService purchaseService;
        public DefaultCommand addCommand { get; }

        public PurchaseViewModel()
        {
            Purchases = new ObservableCollection<PurchaseDTO>();
            currentPurchase = new PurchaseDTO();
            purchaseService = new PurchaseService();
            addCommand = new DefaultCommand(add);
        }

        public void add()
        {
            try
            {
                purchaseService.add(currentPurchase);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

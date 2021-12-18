using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FurnitureStoreApp.Viewmodel;

namespace FurnitureStoreApp.View
{
    /// <summary>
    /// Interaction logic for NewCostumerView.xaml
    /// </summary>
    public partial class NewCostumerView : UserControl
    {
        ProductViewModel productViewModel;
        public NewCostumerView()
        {
            InitializeComponent();
            productViewModel = new ProductViewModel();
        }

        
    }
}

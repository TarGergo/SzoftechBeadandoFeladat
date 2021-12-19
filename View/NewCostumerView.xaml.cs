using FurnitureStoreApp.Viewmodel;
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


namespace FurnitureStoreApp.View
{
    /// <summary>
    /// Interaction logic for NewCostumerView.xaml
    /// </summary>
    public partial class NewCostumerView : UserControl
    {
       
        public NewCostumerView()
        {
            ProductViewModel productViewModel;
            InitializeComponent();
            productViewModel = new ProductViewModel();
          

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

       
    }
}

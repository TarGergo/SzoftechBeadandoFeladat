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

namespace FurnitureStoreApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        ProductViewModel productViewModel;

        public MainWindow()
        {
            InitializeComponent();
            productViewModel = new ProductViewModel();
            DataContext = productViewModel;
            cLView.Visibility = Visibility.Collapsed;
            nCView.Visibility = Visibility.Collapsed;
            sView.Visibility = Visibility.Collapsed;
            pLView.Visibility = Visibility.Collapsed;

        }

        private void closeBttn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void tgglBttn_Unchecked(object sender, RoutedEventArgs e)
        {
            cLView.Opacity = 1;
            nCView.Opacity = 1;
            sView.Opacity = 1;
        }

        private void tgglBttn_Checked(object sender, RoutedEventArgs e)
        {
            cLView.Opacity = 0.3;
            nCView.Opacity = 0.3;
            sView.Opacity = 0.3;
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (tgglBttn.IsChecked==true)
            {
                tltCostumer.Visibility = Visibility.Collapsed;
                tltNewCostumer.Visibility = Visibility.Collapsed;
                tltStorage.Visibility = Visibility.Collapsed;
                tltPurchase.Visibility = Visibility.Collapsed;

            }
            else
            {
                tltCostumer.Visibility = Visibility.Visible;
                tltNewCostumer.Visibility = Visibility.Visible;
                tltStorage.Visibility = Visibility.Visible;
                tltPurchase.Visibility = Visibility.Visible;

            }
        }

        private void ListViewItem_GotFocus(object sender, RoutedEventArgs e)
        {
            cLView.Visibility = Visibility.Visible;
            nCView.Visibility = Visibility.Collapsed;
            sView.Visibility = Visibility.Collapsed;
            pLView.Visibility = Visibility.Collapsed;
           
        


    }

        private void ListViewItem_GotFocus_1(object sender, RoutedEventArgs e)
        {
            cLView.Visibility = Visibility.Collapsed;
            nCView.Visibility = Visibility.Visible;
            sView.Visibility = Visibility.Collapsed;
            pLView.Visibility = Visibility.Collapsed;

        }

        private void ListViewItem_GotFocus_2(object sender, RoutedEventArgs e)
        {
            cLView.Visibility = Visibility.Collapsed;
            nCView.Visibility = Visibility.Collapsed;
            sView.Visibility = Visibility.Visible;
            pLView.Visibility = Visibility.Collapsed;
        }

        private void ListViewItem_GotFocus_3(object sender, RoutedEventArgs e)
        {
            cLView.Visibility = Visibility.Collapsed;
            nCView.Visibility = Visibility.Collapsed;
            sView.Visibility = Visibility.Collapsed;
            pLView.Visibility = Visibility.Visible;
        }
    }
}

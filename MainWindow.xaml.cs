using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FurnitureStoreApp.Viewmodel;

namespace FurnitureStoreApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductViewModel ProductViewModel;
        public MainWindow()
        {
            InitializeComponent();
            ProductViewModel = new ProductViewModel();
            DataContext = ProductViewModel;
        }
    }
}

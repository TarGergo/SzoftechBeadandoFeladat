﻿using System;
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

namespace FurnitureStoreApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void closeBttn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void tgglBttn_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void tgglBttn_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        
    }
}

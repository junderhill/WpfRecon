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
using WpfRecon.Models;
using WpfRecon.ViewModels;

namespace WpfRecon
{
    /// <summary>
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class ResultsPage : Page
    {
        private ResultPageVM _resultPageVm;
        private Task scanTask; 
        public ResultsPage()
        {
            InitializeComponent();
            _resultPageVm = new ResultPageVM();
            _resultPageVm.ScanOutputChanged += HandleScanOutputChanged;
            scanTask = resultPageVm.StartScan();
        }

        void HandleScanOutputChanged(object sender, EventArgs e)
        {
            FullResults.Text += _resultPageVm.ScanOutput();
        }
        
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            // View The Home page  
            NavigationService.Navigate(new Uri("Views/MainPage.xaml", UriKind.Relative));
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {

            // View The About page 
            NavigationService.Navigate(new Uri("Views/About.xaml", UriKind.Relative));
        }

        private void Results_Click(object sender, RoutedEventArgs e)
        {
            // View The Results page 
            NavigationService.Navigate(new Uri("Views/Results.xaml", UriKind.Relative));
        }
    }
}

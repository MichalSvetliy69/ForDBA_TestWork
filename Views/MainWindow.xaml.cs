﻿using ForDBA.Data.Repository;
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
using ForDBA.ViewModels;
using ForDBA.Data;


namespace ForDBA.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IRepository userRepository = new Repository();
            //DGrid.ItemsSource = userRepository.GetAbonents();
            DataContext = ViewModelsContainer.mainWindowVM = new MainWindowVM(); //?

            //DataContext = new MainWindowVM();

        }

        private void DGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

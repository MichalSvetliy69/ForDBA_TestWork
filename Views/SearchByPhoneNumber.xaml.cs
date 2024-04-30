using ForDBA.Data;
using ForDBA.ViewModels;
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
using System.Windows.Shapes;

namespace ForDBA.Views
{
    /// <summary>
    /// Interaction logic for SearchByPhoneNumber.xaml
    /// </summary>
    public partial class SearchByPhoneNumber : Window
    {
        public SearchByPhoneNumber()
        {
            InitializeComponent();

            DataContext = ViewModelsContainer.searchByPhoneNumberVMWindowVM = new SearchByPhoneNumberVM(); //?
        }



        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Проверяем, является ли вводимый символ цифрой
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true; // Если символ не цифра, то игнорируем его
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

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
    /// Interaction logic for StreetsInfoListWindow.xaml
    /// </summary>
    public partial class StreetsInfoListWindow : Window
    {
        public StreetsInfoListWindow()
        {
            InitializeComponent();

            DataContext = ViewModelsContainer.StreetsInfoListVM = new StreetsInfoListVM(); //?
        }
    }

}

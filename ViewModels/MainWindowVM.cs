using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ForDBA.Data;
using ForDBA.Data.Models;
using ForDBA.Data.Repository;
using ForDBA.Services.Commands;
using ForDBA.Views;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using ForDBA.Services;

namespace ForDBA.ViewModels
{

    class MainDataGrid
    {
        public string? FIO { get; set; }
        public string? HomeNumber { get; set; }
        public string? StreetName { get; set; }
        public string? HomePhoneNumber { get; set; }
        public string? WorkPhoneNumber { get; set; }
        public string? MobilePhoneNumber { get; set; }
    }



    class MainWindowVM : INotifyPropertyChanged
    {
        List<Abonent> _abonents;
        List<MainDataGrid> _mainDataGridItems;
        public MainWindowVM ()
        {
            IRepository userRepository = new Repository();
            Abonents = userRepository.GetAbonents();
            MainDataGridMapper mainDataGridMapper = new MainDataGridMapper();

            MainDataGridItems = mainDataGridMapper.GetMappingResult(Abonents);
            if (true)
            {

            }    

        }


        public List<Abonent> Abonents 
        {
            get { return _abonents; }
            set
            {

                _abonents = value;
                OnPropertyChanged("Abonents");
            }
        }

        public List<MainDataGrid> MainDataGridItems
        {
            get { return _mainDataGridItems; }
            set
            {

                _mainDataGridItems = value;
                OnPropertyChanged("MainDataGridItems");
            }
        }

        private RelayCommand _openSearchByPhoneNumberWindow;
        public RelayCommand OpenSearchByPhoneNumberWindowCommand
        {
            get
            {
                return _openSearchByPhoneNumberWindow ??
                       (_openSearchByPhoneNumberWindow = new RelayCommand(obj =>
                       {
                           
                               SearchByPhoneNumber window = new SearchByPhoneNumber();
                               window.Show();
                          
                       }));
            }
        }

        private RelayCommand _openStreetsInfoListWindow;
        public RelayCommand OpenStreetsInfoListWindowCommand
        {
            get
            {
                return _openStreetsInfoListWindow ??
                       (_openStreetsInfoListWindow = new RelayCommand(obj =>
                       {
                           
                               StreetsInfoListWindow window = new StreetsInfoListWindow();
                               window.Show();
                          
                       }));
            }
        }

        private RelayCommand _openFileDialog;
        //Nullable<bool> result = openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK;
        public RelayCommand OpenFileDialogCommand
        {
            get
            {
                return _openFileDialog ??
                       (_openFileDialog = new RelayCommand(obj =>
                       {
                           
                               System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                               saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"; // Фильтр для отображаемых типов файлов
                               saveFileDialog.FilterIndex = 1; // Номер фильтра по умолчанию
                               DateTime now = DateTime.Now;
                               // Форматирование даты и времени в нужный формат
                               string formattedDateTime = now.ToString("dd.MM.yy_HH-mm-ss");
                               saveFileDialog.FileName = $"report_{formattedDateTime}.csv"; // Имя файла по умолчанию

                               Nullable<bool> result = saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK; // Получение результата открытия диалогового окна

                               if (result == true)
                               {
                                   string filePath = saveFileDialog.FileName; // Получение пути выбранного файла для сохранения

 

                                   CsvExporter.ExportToCsv(MainDataGridItems, filePath);



                                   MessageBox.Show("Файл успешно сохранен.");
                               }
                           
                       }));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

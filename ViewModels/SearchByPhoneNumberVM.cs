﻿using ForDBA.Data;
using ForDBA.Data.Models;
using ForDBA.Data.Repository;
using ForDBA.Services.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ForDBA.ViewModels
{
    class SearchByPhoneNumberVM : INotifyPropertyChanged
    {
        public SearchByPhoneNumberVM()
        {
            IRepository userRepository = new Repository();
            Abonents = userRepository.GetAbonents();

        }

        private List<Abonent> _abonents;
        public List<Abonent> Abonents
        {
            get { return _abonents; }
            set { _abonents = value; }
        }


        private string _phoneNumber;
        public string NumberForSearch
        {
            get { return _phoneNumber; }
            set 
            {
                _phoneNumber = value;
                //ViewModelsContainer.mainWindowVM.Abonents

                
                var filteredAbonents = Abonents.Where(abonent => abonent.PhoneNumber.MobilePhoneNumber.Contains(_phoneNumber) || abonent.PhoneNumber.HomePhoneNumber.Contains(_phoneNumber) || abonent.PhoneNumber.WorkPhoneNumber.Contains(_phoneNumber)).ToList();
                if (filteredAbonents.Count == 0)
                {
                    Visibility = "Visible";
                }
                else
                {
                    Visibility = "Collapsed";
                }
                ViewModelsContainer.mainWindowVM.Abonents = filteredAbonents;
            }
        }


        private string _visibility = "Collapsed";
        public string Visibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                OnPropertyChanged("Visibility");
            }
        }


        private RelayCommand _closeCommand;
        public RelayCommand CloseCommand
        {
            get
            {
                return _closeCommand ??
                       (_closeCommand = new RelayCommand(obj =>
                       {
                           try
                           {
                               ViewModelsContainer.mainWindowVM.Abonents = Abonents;
                           }
                           catch (Exception ex)
                           {

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
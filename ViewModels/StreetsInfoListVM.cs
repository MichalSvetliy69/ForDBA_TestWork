using ForDBA.Data.Models;
using ForDBA.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDBA.ViewModels
{
    class DataGridForStreetsInfoListVM
    {
        public string StreetName {  get; set; }
        public int AbonentsCount { get; set; }
    }
    class StreetsInfoListVM
    {
        public StreetsInfoListVM()
        {
            IRepository userRepository = new Repository();
            Abonents = userRepository.GetAbonents();
            Streets = userRepository.GetStreets();
            var dataGridForStreetsInfoListVM = new List<DataGridForStreetsInfoListVM>();
            foreach (var street in Streets)
            {
                int n = 0;
                foreach (var abonent in Abonents)
                {
                    if (abonent.Street.StreetName == street.StreetName)
                    {
                        n++;
                    } 
                }
               
                dataGridForStreetsInfoListVM.Add(new DataGridForStreetsInfoListVM { StreetName = street.StreetName, AbonentsCount = n });
                
            }
            DataGrid = dataGridForStreetsInfoListVM;
        }

        private List<DataGridForStreetsInfoListVM> _dataGrid;

        public List<DataGridForStreetsInfoListVM> DataGrid
        {
            get { return _dataGrid; }
            set { _dataGrid = value; }
        }

        private List<Abonent> _abonents;

        public List<Abonent> Abonents
        {
            get { return _abonents; }
            set { _abonents = value; }
        }

        private List<Streets> _streets;

        public List<Streets> Streets
        {
            get { return _streets; }
            set { _streets = value; }
        }
    }



}

using ForDBA.Data.Models;
using ForDBA.ViewModels;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDBA.Services
{
    class MainDataGridMapper
    {
        public MainDataGridMapper()
        {
            
        }

        public List<MainDataGrid> GetMappingResult(List<Abonent> abonentsList)
        {
            var result = new List<MainDataGrid>();
            foreach (var abonent in abonentsList)
            {
                var mainDataGridItem = new MainDataGrid()
                {
                    FIO = $"{abonent.Name} {abonent.LastName} {abonent.SurName}",
                    HomeNumber = abonent.Address.HomeNumber,
                    StreetName = abonent.Address.Street.StreetName,

                };

                //if (abonent.PhoneNumbers.Count != null)
                //{
                //    mainDataGridItem.HomePhoneNumber = abonent.PhoneNumbers.FirstOrDefault(n => n.Type == "HomePhoneNumber").Number;
                //    mainDataGridItem.WorkPhoneNumber = abonent.PhoneNumbers.FirstOrDefault(n => n.Type == "WorkPhoneNumber").Number;
                //    mainDataGridItem.MobilePhoneNumber = abonent.PhoneNumbers.FirstOrDefault(n => n.Type == "MobilePhoneNumber").Number;
                //}
                

                result.Add(mainDataGridItem);
            }

            return result;
        }
    }
}

using ForDBA.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDBA.Data.Repository
{
    interface IRepository
    {
        //void Create(Abonent abonent);
        //void Delete(int id);
        //Abonent Get(int id);
        //void Update(Abonent abonent);
        List<Abonent> GetAbonents();
        List<Address> GetAddresses();
        List<PhoneNumber> GetPhoneNumbers();
        List<Streets> GetStreets();

        
    }
}

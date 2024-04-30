using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDBA.Data.Models
{
    class Abonent : BaseModel
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
        public Address Address { get; set; }


    }
}

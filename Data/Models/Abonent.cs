using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDBA.Data.Models
{
    class Abonent : BaseModel
    {
        public string FIO { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Address Address { get; set; }
        public Streets Street { get; set; }

    }
}

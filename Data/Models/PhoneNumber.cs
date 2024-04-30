using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDBA.Data.Models
{
    class PhoneNumber : BaseModel
    {
        public string HomePhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
    }
}

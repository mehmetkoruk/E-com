using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EticaretShoes.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string surName { get; set; }
        public string Country { get; set; }
        public string stretAdress { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        
        public int CartNo { get; set; }
    }
}

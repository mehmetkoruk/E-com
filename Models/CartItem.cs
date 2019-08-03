using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EticaretShoes.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
       
        public int ShoesId { get; set; }
        
        public int CartId { get; set; }
        public int Amount { get; set; }
    }
}

using EticaretShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EticaretShoes.Interface
{
   public  interface ICart
    {
       string CreateCart();
       Cart UpdateCart(int CartId);
        int AddCart();

    }
}

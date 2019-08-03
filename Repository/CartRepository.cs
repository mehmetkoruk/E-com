using EticaretShoes.Interface;
using EticaretShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EticaretShoes.Repository
{
    public class CartRepository : ICart
    {
        private Context con;
        public CartRepository(Context _con)
        {
            con = _con;
        }
        public Cart UpdateCart(int CartId)
        {
            Cart y = new Cart();
            y = con.Carts.Where(x => x.CartId == CartId).FirstOrDefault();
            y.UserId = CartId.ToString();
            con.SaveChanges();

            return y;
        }

        public string CreateCart()
        {
            Cart ccc = new Cart();
            con.Carts.Add(ccc);
            con.SaveChanges();
            var x = ccc.CartId;
            con.SaveChanges();
            return x.ToString();
        }
        public int AddCart()
        {
          Cart x=  con.Carts.LastOrDefault();
            return Convert.ToInt32( x.UserId);
        }
        
    }
}

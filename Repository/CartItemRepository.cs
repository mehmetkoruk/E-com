using EticaretShoes.Interface;
using EticaretShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EticaretShoes.Repository
{
    public class CartItemRepository : ICartItem
    {
        private Context con;
        public CartItemRepository(Context _con)
        {
            con = _con;
        }



        IQueryable<CartItem> ICartItem.CartItems => con.CartItems;

        public CartItem AddToCart(int shoesId,int cartId)
        {
            CartItem yenikartitem = new CartItem();
            yenikartitem.ShoesId = shoesId;
            yenikartitem.CartId = cartId;
            con.CartItems.Add(yenikartitem);
            con.SaveChanges();
            return yenikartitem;
        }

      

        public void CreateCartItem()
        {
            throw new NotImplementedException();
        }

        public void DelCartitem(int cartid, int shoesid)
        {
            var items = con.CartItems.First(x => x.CartId == cartid && x.ShoesId == shoesid);
            con.CartItems.Remove(con.CartItems.First(x => x.CartId == cartid && x.ShoesId == shoesid));
            con.SaveChanges();
        }

        public CartItem RemoveFromCart(int shoesId)
        {
            throw new NotImplementedException();
        }
    }
}

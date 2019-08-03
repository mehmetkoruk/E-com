using EticaretShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EticaretShoes.Interface
{
   public interface ICartItem
    {
        IQueryable<CartItem> CartItems { get; }
        void CreateCartItem();
        CartItem AddToCart(int shoesId,int cartId);
        CartItem RemoveFromCart(int shoesId);
        void DelCartitem(int cartid,int shoesid);

    }
}

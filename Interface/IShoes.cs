using EticaretShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EticaretShoes.Interface
{
     public interface IShoes
    {
        IQueryable<Shoes> Shoes { get; }
        List<Shoes> ShoesList();
        Shoes GetByID(int ID);
        Shoes AddProduct(Shoes s);
        Shoes UpdateProduct(Shoes s);
        void DelProduct(Shoes s);

    }
}

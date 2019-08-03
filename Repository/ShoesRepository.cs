using EticaretShoes.Interface;
using EticaretShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EticaretShoes.Repository
{
    public class ShoesRepository : IShoes
    {
        private Context con;
        public ShoesRepository(Context _con)
        {
            con = _con;
        }
        public IQueryable<Shoes> Shoes => con.Shoes;

        public Shoes AddProduct(Shoes s)
        {
            con.Shoes.Add(s);
            con.SaveChanges();
            return s;
        }

        public void DelProduct(Shoes s)
        {
            con.Shoes.Remove(s);
            con.SaveChanges();
        }

        public Shoes GetByID(int ID)
        {
            return con.Shoes.Where(x => x.ShoesId == ID).FirstOrDefault();
        }

        public List<Shoes> ShoesList()
        {
            throw new NotImplementedException();
        }

        public Shoes UpdateProduct(Shoes s)
        {
            throw new NotImplementedException();
        }
    }
}

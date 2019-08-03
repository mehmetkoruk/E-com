using EticaretShoes.Interface;
using EticaretShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EticaretShoes.Repository
{
    public class CategoryRepository : ICategory
    {
        private Context con;
        public CategoryRepository(Context _con)
        {
            con = _con;
        }
        public IQueryable<Category> GetCategories => con.Categories; 
    }
}

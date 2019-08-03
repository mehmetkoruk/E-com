using EticaretShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EticaretShoes.Interface
{
  public  interface ICategory
    {
        IQueryable<Category> GetCategories { get; }
    }
}

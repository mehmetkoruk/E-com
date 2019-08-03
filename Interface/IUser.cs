using EticaretShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EticaretShoes.Interface
{
     public interface IUser
    {
        IQueryable<User> Users { get; }
        void CreateUser();
        void AddUser(User a);
    }
}

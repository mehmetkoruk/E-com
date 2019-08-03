using EticaretShoes.Interface;
using EticaretShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EticaretShoes.Repository
{
    public class UserRepository : IUser
    {
        private Context con;
        public UserRepository(Context  _con)
        {
            con = _con;
        }

        public IQueryable<User> Users => throw new NotImplementedException();

        public void AddUser(User a)
        {
            con.Users.Add(a);
        }

        public void CreateUser()
        {
            throw new NotImplementedException();
        }
    }
}

using Orange.Data;
using Orange.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orange.Data.Repositories
{
    /// <summary>
    /// User Repository models from http://stackoverflow.com/questions/1970655/asp-net-mvc-and-login-authentication  
    /// </summary>
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(ApplicationDbContext dataContext)
            : base(dataContext)
        {
        }

        public User GetByUserName(string userName)
        {
            return DbSet.SingleOrDefault(u => u.UserName == userName);
        }

        public User GetByStringId(string id)
        {
            return DbSet.SingleOrDefault(u => u.Id == id);
        }
    }
}

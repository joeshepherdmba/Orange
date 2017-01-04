using Orange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orange.Data.Repositories
{
    public interface IUserRepository
    {
        User GetByUserName(string userName);
        User GetByStringId(string id);
        //Task<ApplicationUser> LoginAsync(string userName, string password);
        //Task<bool> RegisterAsync(string userName, string email, string password);
        //Task<bool> ChangePasswordAsync(string id, string newPassword);
    }
}

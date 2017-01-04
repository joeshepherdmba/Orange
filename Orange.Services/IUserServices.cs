using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orange.Services.BusinessEntities;

namespace Orange.Services
{
    public interface IUserServices
    {
        UserEntity GetById(string id);
        UserEntity GetByUserName(string userName);
        IEnumerable<UserEntity> GetAllUsers();
        string Create(UserEntity user);
        bool Update(UserEntity user);
        bool Delete(UserEntity user);
    }
}

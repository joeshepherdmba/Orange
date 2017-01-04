using Orange.Data.Repositories;
using Orange.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Orange.Model;
using Orange.Services.BusinessEntities;


namespace Orange.Services
{
    public class UserServices: IUserServices
    {
        private UnitOfWork _unitOfWork;

        public UserServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public string Create(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserEntity GetById(string id)
        {
            var user = _unitOfWork.UserRepository.GetByStringId(id);
            if(user!=null)
            {
                Mapper.CreateMap<User, UserEntity>();
                var userModel = Mapper.Map<User, UserEntity>(user);
                return userModel;
            }
            return null;
        }

        public UserEntity GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserEntity user)
        {
            throw new NotImplementedException();
        }
    }
}

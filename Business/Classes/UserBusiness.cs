using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.General;
using Entities.Classes;
using Entities.Exceptions;
using Entities.Constants;

namespace Business.Classes
{
    public class UserBusiness : BaseBusiness
    {
        public void Save(User user)
        {
            Factory.UsersRepository.Save(user);
        }

        public User FindById(long id)
        {
            User user = Factory.UsersRepository.FindById(id);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new BusinessException(BusinessConstants.USER_NOT_FOUND);
            }
        }

        public User FindUserByAccountAndPassword(string account, string password)
        {
            return Factory.UsersRepository.FindUserByAccountAndPassword(account, password);
        }

        public void Delete(long id)
        {
            User user = Factory.UsersRepository.FindById(id);
            if (user == null)
            {
                throw new BusinessException(BusinessConstants.USER_NOT_FOUND);
            }
            Factory.UsersRepository.Delete(user);
        }

        public List<User> FindAllUsers()
        {
            return Factory.UsersRepository.FindAll().ToList();
        }
    }
}

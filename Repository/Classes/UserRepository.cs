using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.Classes;
using System.Linq.Expressions;
using Repository.General;

namespace Repository.Classes
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(GiftShopDbContext context) : base(context) { }

        public new void Save(User user)
        {
            User userSaved = FindById(user.Id);
            if (userSaved == null)
            {
                userSaved = new User();
            }
            userSaved.Name = user.Name;
            userSaved.Account = user.Account;
            userSaved.Password = user.Password;
            userSaved.UserRole = user.UserRole;
            userSaved.Available = user.Available;
            base.Save(userSaved);
        }

        public User FindUserByAccountAndPassword(string account, string password)
        {
            var filters = CreateFiltersList();
            filters.Add(u => u.Account == account);
            filters.Add(u => u.Password == password);
            filters.Add(u => u.Available);
            return FindUniqueByFilters(filters);
        }
    }
}

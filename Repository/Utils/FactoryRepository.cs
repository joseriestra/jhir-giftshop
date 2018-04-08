using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Repository.Classes;
using Repository.General;

namespace Repository.Utils
{
    public class FactoryRepository
    {
        private GiftShopDbContext dbContext;

        public FactoryRepository()
        {
            this.dbContext = new GiftShopDbContext();
        }

        public UserRepository UsersRepository { get { return new UserRepository(this.dbContext); } }
        public ProductRepository ProductsRepository { get { return new ProductRepository(this.dbContext); } }
        public OrderRepository OrdersRepository { get { return new OrderRepository(this.dbContext); } }
        public CategoryRepository CategoriesRepository { get { return new CategoryRepository(this.dbContext); } }
    }
}

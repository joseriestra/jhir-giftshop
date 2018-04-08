using Entities.Classes;
using Repository.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository.Classes
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(GiftShopDbContext context) : base(context) { }

        public new void Save(Order order)
        {
            Order orderSaved = FindById(order.Id , "Products", "User");
            if (orderSaved == null)
            {
                orderSaved = new Order();
                orderSaved.OrderDate = DateTime.Now;
                orderSaved.Products = order.Products;
            }
            orderSaved.UserId = order.UserId;
            orderSaved.Total = order.Products.Sum(p => p.Price);
            orderSaved.ShippingAdress = order.ShippingAdress;
            orderSaved.PayMentMethod = order.PayMentMethod;
            base.Save(orderSaved);
        }

        public Order FindHistoryOrdersByUser(long userId)
        {
            var filters = CreateFiltersList();
            filters.Add(f => f.UserId == userId);
            return base.FindUniqueByFilters(filters);
        }
    }
}

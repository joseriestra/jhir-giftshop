using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Classes
{
    public class Order : BaseEntity
    {
        public Order()
        {
            Products = new List<OrderProducts>();
        }
        public DateTime OrderDate { get; set; }
        public List<OrderProducts> Products { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
        public string ShippingAdress { get; set; }
        public PaymentMethod PayMentMethod { get; set; }
        public double Total { get; set; }
    }
}

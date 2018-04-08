using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Classes
{
    public class OrderProducts : BaseEntity
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public Order Order { get; set; }
        public long OrderId { get; set; }
    }
}

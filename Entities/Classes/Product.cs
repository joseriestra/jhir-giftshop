using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Classes
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public Category Category { get; set; }
        public long CategoryId { get; set; }
        public bool Available { get; set; }
    }
}

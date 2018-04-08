using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Classes
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public bool Available { get; set; }
        public List<Product> Products { get; set; }
    }
}

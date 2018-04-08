using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Classes;

namespace Business.Utils
{
    public class FactoryBusiness
    {
        public FactoryBusiness() { }
        public UserBusiness UserBusiness { get { return new UserBusiness(); } }
        public ProductBusiness ProductBusiness { get { return new ProductBusiness(); } }
        public OrderBusiness OrderBusiness { get { return new OrderBusiness(); } }
        public CategoryBusiness CategoryBusiness { get { return new CategoryBusiness(); } }
    }
}

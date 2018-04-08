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
    public class ProductBusiness : BaseBusiness
    {
        public void Save(Product product)
        {
            Factory.ProductsRepository.Save(product);
        }

        public Product FindById(long id)
        {
            Product product = Factory.ProductsRepository.FindById(id);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new BusinessException(BusinessConstants.PRODUCT_NOT_FOUND);
            }
        }

        public void Delete(long id)
        {
            Product product = Factory.ProductsRepository.FindById(id);
            if (product == null)
            {
                throw new BusinessException(BusinessConstants.USER_NOT_FOUND);
            }
            Factory.ProductsRepository.Delete(product);
        }

        public IList<Product> FindProductsByCategoryId(long categoryId)
        {
            return Factory.ProductsRepository.FindProductsByCategory(categoryId);
        }

        public IList<Product> FindAllProducts()
        {
            return Factory.ProductsRepository.FindAllProducts();
        }
    }
}

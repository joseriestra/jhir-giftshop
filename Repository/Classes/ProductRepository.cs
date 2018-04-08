using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.Classes;
using System.Linq.Expressions;
using Repository.General;

namespace Repository.Classes
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(GiftShopDbContext context) : base(context) { }

        public new void Save(Product product)
        {
            Product productSaved = FindById(product.Id, "Category");
            if (productSaved == null)
            {
                productSaved = new Product();
                productSaved.Available = true;
            }
            productSaved.ProductName = product.ProductName;
            productSaved.ProductCode = product.ProductCode;
            productSaved.Description = product.Description;
            productSaved.Price = product.Price;
            productSaved.ImagePath = product.ImagePath;
            productSaved.CategoryId = product.CategoryId;
            productSaved.Available = product.Available;
            base.Save(productSaved);
        }

        public IList<Product> FindAllProducts()
        {
            return base.FindAll("Category");
        }

        public IList<Product> FindProductsByCategory(long categoryId)
        {
            var filters = CreateFiltersList();
            filters.Add(p => p.CategoryId == categoryId);
            return FindByFilters(filters);
        }

        public Product FindById(long id)
        {
            return base.FindById(id, "Category");
        }
    }
}

using Entities.Classes;
using Repository.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Classes
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(GiftShopDbContext context) : base(context) { }

        public new void Save(Category category)
        {
            Category categorySaved = FindById(category.Id, "Products");
            if (categorySaved == null)
            {
                categorySaved = new Category();
                categorySaved.Available = true;
            }
            categorySaved.CategoryName = category.CategoryName;
            base.Save(categorySaved);
        }
    }
}

using Business.General;
using Entities.Classes;
using Entities.Constants;
using Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Classes
{
    public class CategoryBusiness : BaseBusiness
    {
        public void Save(Category category)
        {
            Factory.CategoriesRepository.Save(category);
        }

        public Category FindById(long id)
        {
            Category category = Factory.CategoriesRepository.FindById(id);
            if (category != null)
            {
                return category;
            }
            else
            {
                throw new BusinessException(BusinessConstants.CATEGORY_NOT_FOUND);
            }
        }

        public void Delete(long id)
        {
            Category category = Factory.CategoriesRepository.FindById(id);
            if (category == null)
            {
                throw new BusinessException(BusinessConstants.CATEGORY_NOT_FOUND);
            }
            Factory.CategoriesRepository.Delete(category);
        }

        public IList<Category> FindAllCategories()
        {
            return Factory.CategoriesRepository.FindAll();
        }
    }
}

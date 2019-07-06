using Recipe.Business.Abstract;
using Recipe.DataAccess.Concrete.LiteDb;
using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Business.Concrete.LiteDb
{
    public class LDCategoryManager : ICategoryService
    {

        private LDCategoryDal _categoryDal = new LDCategoryDal("Categories");

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(int Id)
        {
            _categoryDal.Delete(Id);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int Id)
        {
            return _categoryDal.GetById(Id);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}

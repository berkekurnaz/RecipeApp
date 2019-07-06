using Recipe.Entities.Abstract;
using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.DataAccess.Abstract
{
    public interface IBaseRepository<T> where T : BaseEntity, IEntity, new()
    {
        List<T> GetAll();
        T GetById(int Id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int Id);
    }
}

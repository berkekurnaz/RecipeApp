using Recipe.Business.Abstract;
using Recipe.DataAccess.Concrete.LiteDb;
using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Business.Concrete.LiteDb
{
    public class LDAuthorManager : IAuthorService
    {

        private LDAuthorDal _authorDal = new LDAuthorDal("Authors");

        public void Add(Author author)
        {
            _authorDal.Add(author);
        }

        public void Delete(int Id)
        {
            _authorDal.Delete(Id);
        }

        public List<Author> GetAll()
        {
           return _authorDal.GetAll();
        }

        public Author GetById(int Id)
        {
            return _authorDal.GetById(Id);
        }

        public void Update(Author author)
        {
            _authorDal.Update(author);
        }
    }
}

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

        string repoName;
        private LDAuthorDal _authorDal;

        public LDAuthorManager(string repoName)
        {
            this.repoName = repoName;
            _authorDal = new LDAuthorDal(repoName);
        }

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

        public Author Login(Author author)
        {
            var result = new Author();
            result = _authorDal.GetAll().Find(x => x.Username == author.Username && x.Password == author.Password);
            return result;
        }

    }
}

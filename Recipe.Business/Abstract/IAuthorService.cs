using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Business.Abstract
{
    public interface IAuthorService
    {
        List<Author> GetAll();
        Author GetById(int Id);
        void Add(Author author);
        void Update(Author author);
        void Delete(int Id);
        Author Login(Author author);
        Author CheckByApiKey(string apiKey);
    }
}

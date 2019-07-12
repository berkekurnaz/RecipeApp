using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Business.Abstract
{
    public interface IArticleService
    {
        List<Article> GetAll();
        Article GetById(int Id);
        void Add(Article article);
        void Update(Article article);
        void Delete(int Id);
        void DeleteByCategoryId(int CategoryId);
        void DeleteByAuthorId(int authorId);
    }
}

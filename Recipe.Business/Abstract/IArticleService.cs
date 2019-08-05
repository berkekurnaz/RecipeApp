using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Business.Abstract
{
    public interface IArticleService
    {
        List<Article> GetAll();
        List<Article> GetArticesBySearch(string searchText);
        List<Article> GetArticlesByCategoryId(int categoryId);
        List<Article> GetRecentlyArticles(int count);
        List<Article> GetMostPopularArticles();
        Article GetById(int Id);
        void Add(Article article);
        void Update(Article article);
        void Delete(int Id);
        void DeleteByCategoryId(int CategoryId);
        void DeleteByAuthorId(int authorId);
    }
}

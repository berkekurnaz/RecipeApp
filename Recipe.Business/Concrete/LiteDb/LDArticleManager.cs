using Recipe.Business.Abstract;
using Recipe.DataAccess.Concrete.LiteDb;
using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipe.Business.Concrete.LiteDb
{
    public class LDArticleManager : IArticleService
    {

        string repoName;
        private LDArticleDal _articleDal;

        public LDArticleManager(string repoName)
        {
            this.repoName = repoName;
            _articleDal = new LDArticleDal(repoName);
        }

        public void Add(Article article)
        {
            _articleDal.Add(article);
        }

        public void Delete(int Id)
        {
            _articleDal.Delete(Id);
        }

        public void DeleteByCategoryId(int categoryId)
        {
            List<Article> articles = _articleDal.GetAll().FindAll(x => x.Category.Id == categoryId);
            for (int i = 0; i < articles.Count; i++)
            {
                _articleDal.Delete(articles[i].Id);
            }
        }

        public void DeleteByAuthorId(int authorId)
        {
            List<Article> articles = _articleDal.GetAll().FindAll(x => x.Author.Id == authorId);
            for (int i = 0; i < articles.Count; i++)
            {
                _articleDal.Delete(articles[i].Id);
            }
        }

        public List<Article> GetAll()
        {
            return _articleDal.GetAll();
        }

        public List<Article> GetArticlesByCategoryId(int categoryId)
        {
            return _articleDal.GetAll().Where(x => x.Category.Id == categoryId).ToList();
        }

        public List<Article> GetArticesBySearch(string searchText)
        {
            return _articleDal.GetAll().Where(x => x.Title.Contains(searchText)).OrderByDescending(x => x.Id).ToList();
        }

        public List<Article> GetRecentlyArticles(int count)
        {
            return _articleDal.GetAll().OrderByDescending(x => x.Id).Take(count).ToList();
        }

        public List<Article> GetMostPopularArticles()
        {
            return _articleDal.GetAll().OrderByDescending(x => x.ReadCount).Take(5).ToList();
        }

        public Article GetById(int Id)
        {
            return _articleDal.GetById(Id);
        }

        public void Update(Article article)
        {
            _articleDal.Update(article);
        }

        public void UpdateByAuthorId(int authorId)
        {
            List<Article> articles = _articleDal.GetAll().FindAll(x => x.Author.Id == authorId);
            for (int i = 0; i < articles.Count; i++)
            {
                LDAuthorManager authorManager = new LDAuthorManager("Authors");
                articles[i].Author = authorManager.GetById(authorId);
                _articleDal.Update(articles[i]);
            }
        }

        public void UpdateByCategoryId(int categoryId)
        {
            List<Article> articles = _articleDal.GetAll().FindAll(x => x.Category.Id == categoryId);
            for (int i = 0; i < articles.Count; i++)
            {
                LDCategoryManager categoryManager = new LDCategoryManager("Categories");
                articles[i].Category = categoryManager.GetById(categoryId);
                _articleDal.Update(articles[i]);
            }
        }

    }
}

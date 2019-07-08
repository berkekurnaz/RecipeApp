﻿using Recipe.Business.Abstract;
using Recipe.DataAccess.Concrete.LiteDb;
using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
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

        public List<Article> GetAll()
        {
            return _articleDal.GetAll();
        }

        public Article GetById(int Id)
        {
            return _articleDal.GetById(Id);
        }

        public void Update(Article article)
        {
            _articleDal.Update(article);
        }
    }
}

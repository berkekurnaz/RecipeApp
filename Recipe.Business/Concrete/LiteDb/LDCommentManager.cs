using Recipe.Business.Abstract;
using Recipe.DataAccess.Concrete.LiteDb;
using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipe.Business.Concrete.LiteDb
{
    public class LDCommentManager : ICommentService
    {

        string repoName;
        private LDCommentDal _commentDal;

        public LDCommentManager(string repoName)
        {
            this.repoName = repoName;
            _commentDal = new LDCommentDal(repoName);
        }

        public void Add(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public void Delete(int Id)
        {
            _commentDal.Delete(Id);
        }

        public void DeleteByArticleId(int articleId)
        {
            List<Comment> comments = _commentDal.GetAll().FindAll(x => x.Article.Id == articleId);
            for (int i = 0; i < comments.Count; i++)
            {
                _commentDal.Delete(comments[i].Id);
            }
        }

        public void DeleteByCategoryId(int categoryId)
        {
            List<Comment> comments = _commentDal.GetAll().FindAll(x => x.Article.Category.Id == categoryId);
            for (int i = 0; i < comments.Count; i++)
            {
                _commentDal.Delete(comments[i].Id);
            }
        }

        public void DeleteByAuthorId(int authorId)
        {
            List<Comment> comments = _commentDal.GetAll().FindAll(x => x.Article.Author.Id == authorId);
            for (int i = 0; i < comments.Count; i++)
            {
                _commentDal.Delete(comments[i].Id);
            }
        }

        public void DeleteByUserId(int userId)
        {
            List<Comment> comments = _commentDal.GetAll().FindAll(x => x.User.Id == userId);
            for (int i = 0; i < comments.Count; i++)
            {
                _commentDal.Delete(comments[i].Id);
            }
        }

        public List<Comment> GetAll()
        {
            return _commentDal.GetAll();
        }

        public List<Comment> GetAllByArticle(int articleId, int count)
        {
            return _commentDal.GetAll().FindAll(x => x.Article.Id == articleId).OrderByDescending(x => x.Id).Take(count).ToList();
        }

        public List<Comment> GetAllByUser(int userId)
        {
            return _commentDal.GetAll().FindAll(x => x.User.Id == userId).OrderByDescending(x => x.Id).ToList();
        }

        public Comment GetById(int Id)
        {
            return _commentDal.GetById(Id);
        }

        public void Update(Comment comment)
        {
            _commentDal.Update(comment);
        }

        public void UpdateByUserId(int userId)
        {
            List<Comment> comments = _commentDal.GetAll().FindAll(x => x.User.Id == userId);
            for (int i = 0; i < comments.Count; i++)
            {
                LDUserManager userManager = new LDUserManager("Users");
                comments[i].User = userManager.GetById(userId);
                _commentDal.Update(comments[i]);
            }
        }

    }
}

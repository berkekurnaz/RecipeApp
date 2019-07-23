using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Business.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetAll();
        List<Comment> GetAllByArticle(int articleId, int count);
        Comment GetById(int Id);
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(int Id);
        void DeleteByArticleId(int articleId);
        void DeleteByCategoryId(int categoryId);
        void DeleteByAuthorId(int authorId);
        void DeleteByUserId(int userId);
    }
}

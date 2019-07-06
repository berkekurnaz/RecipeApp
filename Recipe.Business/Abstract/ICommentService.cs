using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Business.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetAll();
        Comment GetById(int Id);
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(int Id);
    }
}

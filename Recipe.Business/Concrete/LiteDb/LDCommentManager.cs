using Recipe.Business.Abstract;
using Recipe.DataAccess.Concrete.LiteDb;
using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
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

        public List<Comment> GetAll()
        {
            return _commentDal.GetAll();
        }

        public Comment GetById(int Id)
        {
            return _commentDal.GetById(Id);
        }

        public void Update(Comment comment)
        {
            _commentDal.Update(comment);
        }
    }
}

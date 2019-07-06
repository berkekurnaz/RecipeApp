using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.DataAccess.Concrete.LiteDb
{
    public class LDCommentDal : LDBaseRepository<Article>
    {

        string repoName;

        public LDCommentDal(string repoName) : base(repoName)
        {
            this.repoName = repoName;
        }

    }
}

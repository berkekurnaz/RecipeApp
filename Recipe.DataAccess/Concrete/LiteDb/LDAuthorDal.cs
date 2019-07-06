using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.DataAccess.Concrete.LiteDb
{
    public class LDAuthorDal : LDBaseRepository<Article>
    {

        string repoName;

        public LDAuthorDal(string repoName) : base(repoName)
        {
            this.repoName = repoName;
        }

    }
}

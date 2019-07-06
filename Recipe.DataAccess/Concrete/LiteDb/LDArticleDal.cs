using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.DataAccess.Concrete.LiteDb
{
    public class LDArticleDal : LDBaseRepository<Article>
    {

        string repoName;

        public LDArticleDal(string repoName) : base(repoName)
        {
            this.repoName = repoName;
        }

    }
}

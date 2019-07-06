using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.DataAccess.Concrete.LiteDb
{
    public class LDContactDal : LDBaseRepository<Article>
    {

        string repoName;

        public LDContactDal(string repoName) : base(repoName)
        {
            this.repoName = repoName;
        }

    }
}

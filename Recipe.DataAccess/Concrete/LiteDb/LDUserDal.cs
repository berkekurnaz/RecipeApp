using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.DataAccess.Concrete.LiteDb
{
    public class LDUserDal : LDBaseRepository<Article>
    {

        string repoName;

        public LDUserDal(string repoName) : base(repoName)
        {
            this.repoName = repoName;
        }

    }
}

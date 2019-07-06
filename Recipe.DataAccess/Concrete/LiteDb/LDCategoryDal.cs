using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.DataAccess.Concrete.LiteDb
{
    public class LDCategoryDal : LDBaseRepository<Article>
    {

        string repoName;

        public LDCategoryDal(string repoName) : base(repoName)
        {
            this.repoName = repoName;
        }

    }
}

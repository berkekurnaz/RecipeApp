using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.DataAccess.Concrete.LiteDb
{
    public class LDSettingDal : LDBaseRepository<Setting>
    {

        string repoName;

        public LDSettingDal(string repoName) : base(repoName)
        {
            this.repoName = repoName;
        }

    }
}

using Recipe.Business.Abstract;
using Recipe.DataAccess.Concrete.LiteDb;
using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Business.Concrete.LiteDb
{
    public class LDSettingManager : ISettingService
    {

        string repoName;
        private LDSettingDal _settingDal;

        public LDSettingManager(string repoName)
        {
            this.repoName = repoName;
            _settingDal = new LDSettingDal(repoName);
        }

        public void Add(Setting setting)
        {
            _settingDal.Add(setting);
        }

        public void Delete(int Id)
        {
            _settingDal.Delete(Id);
        }

        public Setting GetById(int Id)
        {
            return _settingDal.GetById(Id);
        }

        public void Update(Setting setting)
        {
            _settingDal.Update(setting);
        }
    }
}

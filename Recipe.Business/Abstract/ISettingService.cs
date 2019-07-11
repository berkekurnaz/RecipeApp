using Recipe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Business.Abstract
{
    public interface ISettingService
    {
        Setting GetById(int Id);
        void Add(Setting setting);
        void Update(Setting setting);
        void Delete(int Id);
    }
}

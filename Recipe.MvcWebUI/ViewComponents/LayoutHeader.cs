using Microsoft.AspNetCore.Mvc;
using Recipe.Business.Concrete.LiteDb;
using Recipe.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.MvcWebUI.ViewComponents
{
    public class LayoutHeader : ViewComponent
    {

        LDCategoryManager categoryManager = new LDCategoryManager("Categories");
        LDSettingManager settingManager = new LDSettingManager("Settings");

        public IViewComponentResult Invoke()
        {
            MyLayoutViewModel myLayoutViewModel = new MyLayoutViewModel()
            {
                Setting = settingManager.GetById(1),
                Categories = categoryManager.GetAll()
            };
            return View(myLayoutViewModel);
        }

    }
}

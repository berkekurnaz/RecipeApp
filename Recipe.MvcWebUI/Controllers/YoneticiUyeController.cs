using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipe.Business.Concrete.LiteDb;

namespace Recipe.MvcWebUI.Controllers
{
    public class YoneticiUyeController : Controller
    {

        LDUserManager userManager = new LDUserManager("Users");

        public IActionResult Index()
        {
            return View();
        }

    }
}
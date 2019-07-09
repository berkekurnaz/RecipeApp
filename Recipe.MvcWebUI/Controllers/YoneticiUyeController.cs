using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipe.Business.Concrete.LiteDb;
using Recipe.Entities.Concrete;

namespace Recipe.MvcWebUI.Controllers
{
    public class YoneticiUyeController : Controller
    {

        LDUserManager userManager = new LDUserManager("Users");

        public IActionResult Index()
        {
            var items = userManager.GetAll();
            return View(items);
        }

        public IActionResult Incele(int Id)
        {
            var item = userManager.GetById(Id);
            if (item == null)
            {
                return RedirectToAction("Hata", "Yonetici");
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Sil(int Id)
        {
            var user = userManager.GetById(Id);
            // Uyeye Ait Yorumlar Silinecek.
            if (user.Photo != "defaultuser.png")
            {
                if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "\\wwwroot\\Uye\\" + user.Photo))
                {
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\wwwroot\\Uye\\" + user.Photo);
                }
            }
            userManager.Delete(Id);
            TempData["UyeSilmeBasariMesaj"] = "Üye Başarıyla Silindi...";
            return RedirectToAction("Index");
        }

    }
}
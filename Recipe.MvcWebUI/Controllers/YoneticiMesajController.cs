using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipe.Business.Concrete.LiteDb;
using Recipe.Entities.Concrete;

namespace Recipe.MvcWebUI.Controllers
{
    public class YoneticiMesajController : Controller
    {

        LDContactManager contactManager = new LDContactManager("Contacts");

        public IActionResult Index()
        {
            var items = contactManager.GetAll();
            return View(items);
        }

        public IActionResult Incele(int Id)
        {
            var item = contactManager.GetById(Id);
            if (item == null)
            {
                return RedirectToAction("Hata", "Yonetici");
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Sil(int Id)
        {
            contactManager.Delete(Id);
            TempData["MesajSilmeBasariMesaj"] = "Mesaj Başarıyla Silindi...";
            return RedirectToAction("Index");
        }

    }
}
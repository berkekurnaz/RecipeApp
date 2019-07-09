using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipe.Business.Concrete.LiteDb;
using Recipe.Entities.Concrete;

namespace Recipe.MvcWebUI.Controllers
{
    public class YoneticiYorumController : Controller
    {

        LDCommentManager commentManager = new LDCommentManager("Comments");

        public IActionResult Index()
        { 
            var items = commentManager.GetAll();
            return View(items);
        }

        public IActionResult Incele(int Id)
        {
            var comment = commentManager.GetById(Id);
            if (comment == null)
            {
                return RedirectToAction("Hata", "Yonetici");
            }
            return View(comment);
        }

        [HttpPost]
        public IActionResult Sil(int Id)
        {
            commentManager.Delete(Id);
            TempData["YorumSilmeBasariMesaj"] = "Yorum Başarıyla Silindi...";
            return RedirectToAction("Index");
        }

    }
}
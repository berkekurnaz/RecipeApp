using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Recipe.Business.Concrete.LiteDb;
using Recipe.Entities.Concrete;

namespace Recipe.MvcWebUI.Controllers
{
    public class YoneticiMakaleController : Controller
    {

        LDArticleManager articleManager = new LDArticleManager("Articles");
        LDCategoryManager categoryManager = new LDCategoryManager("Categories");
        LDAuthorManager authorManager = new LDAuthorManager("Authors");

        public IActionResult Index()
        {
            var items = articleManager.GetAll();
            return View(items);
        }

        public IActionResult Incele(int Id)
        {
            var item = articleManager.GetById(Id);
            if (item == null)
            {
                return RedirectToAction("Hata", "Yonetici");
            }
            return View(item);
        }

        public IActionResult Ekle()
        {
            ViewBag.KategoriId = new SelectList(categoryManager.GetAll(), "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Article article, int KategoriId)
        {
            var author = authorManager.GetById(1);
            var category = categoryManager.GetById(KategoriId);

            article.Photo = "defaultarticle.png";
            article.CreatedDate = DateTime.Now.ToShortDateString();
            article.Author = author;
            article.Category = category;
            articleManager.Add(article);
            TempData["MakaleEklemeBasariMesaj"] = "Yeni Makale Başarıyla Oluşturuldu...";
            return RedirectToAction("Index");
        }

        public IActionResult Guncelle(int Id)
        {
            var item = articleManager.GetById(Id);
            if (item == null)
            {
                return RedirectToAction("Hata", "Yonetici");
            }
            ViewBag.KategoriId = new SelectList(categoryManager.GetAll(), "Id", "CategoryName", item.Category.Id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Guncelle(int Id, Article newArticle, int KategoriId)
        {
            var category = categoryManager.GetById(KategoriId);

            Article article = articleManager.GetById(Id);
            article.Title = newArticle.Title;
            article.Content = newArticle.Content;
            article.Category = category;
            articleManager.Update(article);
            TempData["MakaleGuncellemeBasariMesaj"] = "Makale Başarıyla Güncellendi...";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Sil(int Id)
        {
            var article = articleManager.GetById(Id);
            if (article.Photo != "defaultarticle.png")
            {
                if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "\\wwwroot\\Makale\\" + article.Photo))
                {
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\wwwroot\\Makale\\" + article.Photo);
                }
            }
            articleManager.Delete(Id);
            TempData["MakaleSilmeBasariMesaj"] = "Makale Başarıyla Silindi...";
            return RedirectToAction("Index");
        }

    }
}
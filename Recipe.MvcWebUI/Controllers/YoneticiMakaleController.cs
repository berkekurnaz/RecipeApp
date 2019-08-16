using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Recipe.Business.Concrete.LiteDb;
using Recipe.Entities.Concrete;
using Recipe.MvcWebUI.AuthFilter;

namespace Recipe.MvcWebUI.Controllers
{
    [AdminAuthFilter]
    public class YoneticiMakaleController : Controller
    {

        LDArticleManager articleManager = new LDArticleManager("Articles");
        LDCategoryManager categoryManager = new LDCategoryManager("Categories");
        LDAuthorManager authorManager = new LDAuthorManager("Authors");
        LDCommentManager commentManager = new LDCommentManager("Comments");

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
        public async Task<IActionResult> Ekle(Article article, int KategoriId, IFormFile Image)
        {
            int sessionAuthorId = Convert.ToInt32(HttpContext.Session.GetInt32("SessionAuthorId"));
            var author = authorManager.GetById(sessionAuthorId);
            var category = categoryManager.GetById(KategoriId);

            if (Image == null || Image.Length == 0)
            {
                article.Photo = "defaultarticle.png";
            }
            else
            {
                string newImage = Guid.NewGuid().ToString() + Image.FileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Makale", newImage);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                article.Photo = newImage;
            }
            
            article.CreatedDate = DateTime.Now.ToShortDateString();
            article.ReadCount = 0;
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
            Author myauthor = authorManager.GetById(Convert.ToInt32(HttpContext.Session.GetInt32("SessionAuthorId")));

            Article article = articleManager.GetById(Id);
            article.Title = newArticle.Title;
            article.Content = newArticle.Content;
            article.Category = categoryManager.GetById(KategoriId);
            article.Author = myauthor;
            articleManager.Update(article);

            TempData["MakaleGuncellemeBasariMesaj"] = "Makale Başarıyla Güncellendi...";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Sil(int Id)
        {
            var article = articleManager.GetById(Id);
            commentManager.DeleteByArticleId(Id);
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

        public IActionResult Fotograf(int Id)
        {
            var item = articleManager.GetById(Id);
            if (item == null)
            {
                return RedirectToAction("Hata", "Yonetici");
            }
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Fotograf(int Id, Article newArticle, IFormFile Image)
        {
            Article article = articleManager.GetById(Id);
            if (Image != null)
            {
                if (article.Photo != "defaultarticle.png")
                {
                    if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "\\wwwroot\\Makale\\" + article.Photo))
                    {
                        System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\wwwroot\\Makale\\" + article.Photo);
                    }
                }
                string newImage = Guid.NewGuid().ToString() + Image.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Makale", newImage);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                article.Photo = newImage;
            }
            articleManager.Update(article);
            TempData["MakaleFotografBasariMesaj"] = "Makale Fotoğrafı Başarıyla Güncellendi...";
            return RedirectToAction("Index");
        }

    }
}
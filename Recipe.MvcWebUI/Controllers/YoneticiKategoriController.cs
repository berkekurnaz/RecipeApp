using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipe.Business.Concrete.LiteDb;
using Recipe.Entities.Concrete;
using Recipe.MvcWebUI.AuthFilter;

namespace Recipe.MvcWebUI.Controllers
{
    [AdminAuthFilter]
    public class YoneticiKategoriController : Controller
    {

        LDCategoryManager categoryManager = new LDCategoryManager("Categories");
        LDArticleManager articleManager = new LDArticleManager("Articles");
        LDCommentManager commentManager = new LDCommentManager("Comments");

        public IActionResult Index()
        {
            var items = categoryManager.GetAll();
            return View(items);
        }

        [HttpPost]
        public IActionResult Ekle(string CategoryName)
        {
            Category category = new Category(CategoryName);
            categoryManager.Add(category);
            TempData["KategoriEklemeBasariMesaj"] = "Yeni Kategori Başarıyla Oluşturuldu...";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Guncelle(int Id, string CategoryName)
        {
            Category category = categoryManager.GetById(Id);
            category.CategoryName = CategoryName;
            categoryManager.Update(category);
            TempData["KategoriGuncellemeBasariMesaj"] = "Kategori Başarıyla Güncellendi...";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Sil(int Id)
        {
            articleManager.DeleteByCategoryId(Id); // Kategoriye Ait Makaleleri Silme.
            commentManager.DeleteByCategoryId(Id); // Kategoriye Ait Yorumları Silme.
            categoryManager.Delete(Id);
            TempData["KategoriSilmeBasariMesaj"] = "Kategori Ve İlgili Makaleler Başarıyla Silindi...";
            return RedirectToAction("Index");
        }

    }
}
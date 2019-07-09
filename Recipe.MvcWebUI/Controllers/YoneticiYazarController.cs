using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Business.Concrete.LiteDb;
using Recipe.CreatorApiKey.Concrete;
using Recipe.Entities.Concrete;

namespace Recipe.MvcWebUI.Controllers
{
    public class YoneticiYazarController : Controller
    {

        LDAuthorManager authorManager = new LDAuthorManager("Authors");

        /* Listeleme Sayfası */
        public IActionResult Index()
        {
            var items = authorManager.GetAll();
            return View(items);
        }

        /* Inceleme Sayfasi */
        public IActionResult Incele(int Id)
        {
            var item = authorManager.GetById(Id);
            if (item == null)
            {
                return RedirectToAction("Hata", "Yonetici");
            }
            return View(item);
        }

        /* Ekleme Sayfası Ve Ekleme İşlemi */
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Author author)
        {
            author.CreatedDate = DateTime.Now.ToShortDateString();
            author.Photo = "defaultauthor.png";
            author.ApiKey = ApiKeyCreator.GetApiKey();
            authorManager.Add(author);
            TempData["YazarEklemeBasariMesaj"] = "Yeni Yazar Başarıyla Oluşturuldu...";
            return RedirectToAction("Index");
        }

        /* Güncelleme Sayfası Ve Güncelleme İşlemi */
        public IActionResult Guncelle(int Id)
        {
            var item = authorManager.GetById(Id);
            if (item == null)
            {
                return RedirectToAction("Hata", "Yonetici");
            }
            return View(item);
        }
        [HttpPost]
        public IActionResult Guncelle(int Id, Author newAuthor)
        {
            Author author = authorManager.GetById(Id);
            author.NameSurname = newAuthor.NameSurname;
            author.Description = newAuthor.Description;
            author.Username = newAuthor.Username;
            author.Password = newAuthor.Password;
            author.ApiKey = newAuthor.ApiKey;
            authorManager.Update(author);
            TempData["YazarGuncellemeBasariMesaj"] = "Yazar Başarıyla Güncellendi...";
            return RedirectToAction("Index");
        }

        /* Silme Sayfası Ve Silme İşlemi */
        public IActionResult Sil(int Id)
        {
            var item = authorManager.GetById(Id);
            if (item == null)
            {
                return RedirectToAction("Hata", "Yonetici");
            }
            return View(item);
        }
        [HttpPost] 
        public IActionResult Sil(int Id, IFormCollection collection)
        {
            var author = authorManager.GetById(Id);
            if (author.Photo != "defaultauthor.png")
            {
                if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "\\wwwroot\\Yazar\\" + author.Photo))
                {
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\wwwroot\\Yazar\\" + author.Photo);
                }
            }
            // Yazara Ait Yazıları Sil.
            authorManager.Delete(Id);
            TempData["YazarSilmeBasariMesaj"] = "Yazar Başarıyla Silindi...";
            return RedirectToAction("Index");
        }

        /* Fotograf Sayfası Ve Fotograf İşlemi */
        public IActionResult Fotograf(int Id)
        {
            var item = authorManager.GetById(Id);
            if (item == null)
            {
                return RedirectToAction("Hata", "Yonetici");
            }
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Fotograf(int Id, Author newAuthor, IFormFile Image)
        {
            Author author = authorManager.GetById(Id);
            if (Image != null)
            {
                if (author.Photo != "defaultauthor.png")
                {
                    if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "\\wwwroot\\Yazar\\" + author.Photo))
                    {
                        System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\wwwroot\\Yazar\\" + author.Photo);
                    }
                }
                string newImage = Guid.NewGuid().ToString() + Image.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Yazar", newImage);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                author.Photo = newImage;
            }
            authorManager.Update(author);
            TempData["YazarFotografBasariMesaj"] = "Yazar Fotoğrafı Başarıyla Güncellendi...";
            return RedirectToAction("Index");
        }

    }
}
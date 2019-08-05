using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Business.Concrete.LiteDb;
using Recipe.Entities.Concrete;
using Recipe.MvcWebUI.AuthFilter;

namespace Recipe.MvcWebUI.Controllers
{
    public class YoneticiController : Controller
    {

        LDArticleManager articleManager = new LDArticleManager("Articles");
        LDUserManager userManager = new LDUserManager("Users");
        LDCommentManager commentManager = new LDCommentManager("Comments");
        LDContactManager contactManager = new LDContactManager("Contacts");
        LDAuthorManager authorManager = new LDAuthorManager("Authors");
        LDSettingManager settingManager = new LDSettingManager("Settings");

        [AdminAuthFilter]
        public IActionResult Index()
        {
            ViewBag.CountArticle = articleManager.GetAll().Count;
            ViewBag.CountUser = userManager.GetAll().Count;
            ViewBag.CountComment = commentManager.GetAll().Count;
            ViewBag.CountContact = contactManager.GetAll().Count;
            return View();
        }

        public IActionResult Giris()
        {
            if (authorManager.GetAll().Count == 0)
            {
                Author author = new Author("Author","Author Description", "defaultauthor.png", "myapi1881hgftwshjjcc1923mka0001",DateTime.Now.ToShortDateString(), "admin", "1111");
                authorManager.Add(author);
            }
            if (settingManager.GetById(1) == null)
            {
                Setting setting = new Setting();
                setting.Name = "MyBlog";
                setting.Description = "MyBlog Description";
                setting.Mail = "myblog@mail.com";
                setting.Phone = "";
                setting.Icon = "icon.png";
                setting.SeoName = "MyBlog Name";
                setting.SeoHeader = "";
                setting.SeoDescription = "MyBlog Description";
                setting.Facebook = "bos";
                setting.Instagram = "bos";
                setting.Twitter = "bos";
                setting.Youtube = "bos";
                settingManager.Add(setting);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Giris(Author author)
        {
            var newAuthor = authorManager.Login(author);
            if (newAuthor != null)
            {
                HttpContext.Session.SetInt32("SessionAuthorId", newAuthor.Id);
                HttpContext.Session.SetString("SessionAuthorUsername", newAuthor.Username);
                HttpContext.Session.SetString("SessionAuthorName", newAuthor.NameSurname);
                return RedirectToAction("Index", "Yonetici");
            }
            return View();
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Anasayfa");
        }

    }
}
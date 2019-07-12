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

        [HttpPost]
        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Anasayfa");
        }

    }
}
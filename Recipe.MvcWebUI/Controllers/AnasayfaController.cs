using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Business.Concrete.LiteDb;
using Recipe.Entities.Concrete;
using Recipe.MvcWebUI.Models;
using ReflectionIT.Mvc.Paging;

namespace Recipe.MvcWebUI.Controllers
{
    public class AnasayfaController : Controller
    {

        LDArticleManager articleManager = new LDArticleManager("Articles");
        LDCategoryManager categoryManager = new LDCategoryManager("Categories");
        LDCommentManager commentManager = new LDCommentManager("Comments");
        LDSettingManager settingManager = new LDSettingManager("Settings");
        LDContactManager contactManager = new LDContactManager("Contacts");
        LDUserManager userManager = new LDUserManager("Users");

        /* Anasayfa */
        public IActionResult Index()
        {
            MainpageViewModel mainpageViewModel = new MainpageViewModel()
            {
                Categories = categoryManager.GetAll(),
                PopularArticles = articleManager.GetMostPopularArticles(),
                RecentlyArticles2 = articleManager.GetRecentlyArticles(2),
                RecentlyArticles5 = articleManager.GetRecentlyArticles(5)
            };
            return View(mainpageViewModel);
        }

        /* Makale Detay Sayfası */
        public IActionResult Makale(int Id)
        {
            ArticleViewModel articleViewModel = new ArticleViewModel()
            {
                Article = articleManager.GetById(Id),
                Comments = commentManager.GetAllByArticle(Id, 10),
                Categories = categoryManager.GetAll(),
                MostPopular = articleManager.GetMostPopularArticles()
            };
            return View(articleViewModel);
        }

        [HttpPost]
        public IActionResult YorumYap(int Id, Comment comment)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            var user = userManager.GetById(userId);
            var article = articleManager.GetById(Id);
            comment.Article = article;
            comment.User = user;
            comment.CreatedDate = DateTime.Now.ToShortDateString();
            commentManager.Add(comment);
            TempData["YorumBasariMesaj"] = "Başarıyla Yeni Bir Yorum Eklediniz.";
            return RedirectToAction("Makale", new { Id = Id });
        }

        /* Kategoriye Ait Makale Listeleme Sayfası */
        public IActionResult Kategori(int Id, int sayfa=1)
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel()
            {
                Articles = articleManager.GetArticlesByCategoryId(Id),
                Categories = categoryManager.GetAll(),
                Category = categoryManager.GetById(Id),
                PopularArticles = articleManager.GetMostPopularArticles(),
                MyPagingModel = PagingList.Create(articleManager.GetArticlesByCategoryId(Id), 5, sayfa)
            };
            return View(categoryViewModel);
        }

        /* Hakkımızda Sayfası */
        public IActionResult Hakkimizda()
        {
            AboutViewModel aboutViewModel = new AboutViewModel()
            {
                Setting = settingManager.GetById(1),
                Categories = categoryManager.GetAll(),
                PopularArticles = articleManager.GetMostPopularArticles()
            };
            return View(aboutViewModel);
        }

        /* Iletisim Sayfası */
        public IActionResult Iletisim()
        {
            ContactViewModel contactViewModel = new ContactViewModel()
            {
                Setting = settingManager.GetById(1)
            };
            return View(contactViewModel);
        }

        [HttpPost]
        public IActionResult Iletisim(Contact contact)
        {
            contact.CreatedDate = DateTime.Now.ToShortDateString();
            contactManager.Add(contact);
            TempData["ContactSuccessMessage"] = "Mesaj Başarıyla Gönderildi";
            return RedirectToAction("Iletisim");
        }

        /* Hata Sayfasi */
        public IActionResult Hata()
        {
            return View();
        }

        public IActionResult CountPlus(int articleId)
        {
            var article = articleManager.GetById(articleId);
            article.ReadCount += 1;
            articleManager.Update(article);
            return View();
        }

    }
}
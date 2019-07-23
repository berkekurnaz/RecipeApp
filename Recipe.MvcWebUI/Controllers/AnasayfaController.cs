using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipe.Business.Concrete.LiteDb;
using Recipe.MvcWebUI.Models;

namespace Recipe.MvcWebUI.Controllers
{
    public class AnasayfaController : Controller
    {

        LDArticleManager articleManager = new LDArticleManager("Articles");
        LDCategoryManager categoryManager = new LDCategoryManager("Categories");
        LDCommentManager commentManager = new LDCommentManager("Comments");

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

    }
}